using CncIndustrial.Utilities.Constants;
using CncIndustrial.Utilities.Exceptions;
using CncIndustrial.ViewModels.Catalog.ProductImages;
using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
using CncIndustrial.ViewModels.Common;

using CNCIndustrial.Application.Common;

using CNCIndustrial.Data.EF;
using CNCIndustrial.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Catalog.Project
{
    public class ManageProjectService : IManagaProjectService
    {
        private readonly CncIndustrialDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ManageProjectService(CncIndustrialDbContext context, IStorageService storageService)
        {
            
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            project.ViewCount += 1;
            await _context.SaveChangesAsync();

        }

        public async Task<int> Create(ProjectCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<ProjectTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new ProjectTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,

                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        TotalArea = request.TotalArea,
                        VacantArea = request.VacantArea,
                        Area=request.Area,
                        Location=request.Location,
                        MainFunction1 = request.MainFunction1,
                        MainFunction2 = request.MainFunction2,
                        MainFunction3 = request.MainFunction3,
                        MainFunction4 = request.MainFunction4,
                        Summary = request.Summary,
                        AccessibilityAirport = request.AccessibilityAirport,
                        AccessibilityCenter = request.AccessibilityCenter,
                        AccessibilityPort = request.AccessibilityPort,
                        AccessibilityExpressway=request.AccessibilityExpressway,
                        Commerce=request.Commerce,
                        Technical=request.Technical,

                        LanguageId = request.LanguageId,


                    }); 
                }
                else
                {
                    translations.Add(new ProjectTranslation()
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        Description = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
                        TotalArea = request.TotalArea,
                        VacantArea = request.VacantArea,
                        Area = request.Area,
                        Location = request.Location,
                        AccessibilityAirport = request.AccessibilityAirport,
                        AccessibilityCenter = request.AccessibilityCenter,
                        AccessibilityPort = request.AccessibilityPort,
                        AccessibilityExpressway = request.AccessibilityExpressway,
                        LanguageId = language.Id
                    });
                }
            }
            var project = new ProjectLocation()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                iframeMap=request.iframeMap,
                ProjectTranslations = translations
            };
            ////Save image
            if (request.ThumbnailImage != null)
            {
                project.ProjectImages = new List<ProjectImage>()
                {
                   

                    new ProjectImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Projects.Add(project);
               await _context.SaveChangesAsync();
            return project.Id;

        }

        public async Task<int> Delete(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null) throw new CncIndustrialException($"Cannot find a project: {projectId}");

            var images = _context.ProjectImages.Where(i => i.ProjectId == projectId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _context.Projects.Remove(project);

            return await _context.SaveChangesAsync();
        }
       
       

        public async Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Projects
                        join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId
                        join pic in _context.ProjectInCategories on p.Id equals pic.ProjectId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProjectImages on p.Id equals pi.ProjectId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId && pi.IsDefault == true
                        select new { p, pt, pic, pi };
            //2. filter
            //
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
        /*
         * 
         */
        public async Task<int> Update(ProjectUpdateRequest request)
        {
            var product = await _context.Projects.FindAsync(request.Id);
            var productTranslations = await _context.ProjectTranslations.FirstOrDefaultAsync(x => x.ProjectId == request.Id
            && x.LanguageId == request.LanguageId);

            if (product == null || productTranslations == null) throw new CncIndustrialException($"Cannot find a product with id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Area = request.Area;
            productTranslations.TotalArea = request.TotalArea;
            productTranslations.VacantArea = request.VacantArea;
            productTranslations.Location = request.Location;
            productTranslations.MainFunction1 = request.MainFunction1;
            productTranslations.MainFunction2 = request.MainFunction2;
            productTranslations.MainFunction3 = request.MainFunction3;
            productTranslations.MainFunction4 = request.MainFunction4;
            productTranslations.Commerce = request.Commerce;
            productTranslations.Technical = request.Technical;
            productTranslations.Summary = request.Summary;


            

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProjectImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProjectId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProjectImages.Update(thumbnailImage);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddImage(int projectId, ProjectImageCreateRequest request)
        {
            var projectImage = new ProjectImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProjectId = projectId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                projectImage.ImagePath = await this.SaveFile(request.ImageFile);
                projectImage.FileSize = request.ImageFile.Length;
            }
            _context.ProjectImages.Add(projectImage);
            await _context.SaveChangesAsync();
            return projectImage.Id;
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProjectImages.FindAsync(imageId);
            if (productImage == null)
                throw new CncIndustrialException($"Cannot find an image with id {imageId}");
            _context.ProjectImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProjectImageUpdateRequest request)
        {
            var productImage = await _context.ProjectImages.FindAsync(imageId);
            if (productImage == null)
                throw new CncIndustrialException($"Cannot find an image with id {imageId}");
              
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProjectImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

      
        public async Task<List<ProjectImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProjectImages.Where(x => x.ProjectId == productId)
               .Select(i => new ProjectImageViewModel()
               {
                   Caption = i.Caption,
                   DateCreated = i.DateCreated,
                   FileSize = i.FileSize,
                   Id = i.Id,
                   ImagePath = i.ImagePath,
                   IsDefault = i.IsDefault,
                   ProjectId = i.ProjectId,
                   SortOrder = i.SortOrder
               }).ToListAsync();
        }
        public async Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        {
            //1. Select join
            var query = from p in _context.Projects
                        join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId
                        join pic in _context.ProjectInCategories on p.Id equals pic.ProjectId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join pi in _context.ProjectImages on p.Id equals pi.ProjectId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == languageId && (pi == null || pi.IsDefault == true)
                      
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                  
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    Location=x.pt.Location,
                    TotalArea=x.pt.TotalArea,
                    VacantArea=x.pt.VacantArea,
                    ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();

            return data;
        }

        public async Task<List<ProductVm>> GetLatestProducts(string languageId, int take)
        {
            //1. Select join
            var query = from p in _context.Projects
                        join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId
                        join pic in _context.ProjectInCategories on p.Id equals pic.ProjectId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join pi in _context.ProjectImages on p.Id equals pi.ProjectId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == languageId && (pi == null || pi.IsDefault == true)
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                   
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    Location = x.pt.Location,
                    TotalArea = x.pt.TotalArea,
                    VacantArea = x.pt.VacantArea,
                    ThumbnailImage = x.pi.ImagePath
                    
                }).ToListAsync();

            return data;
        }

        //public Task GetById(int productId, string languageId)
        //{
        //    throw new NotImplementedException();
        //}

       public async Task<ProductVm> GetByIdPro(int projectId, string languageId)
        {
            var product = await _context.Projects.FindAsync(projectId);
            var productTranslation = await _context.ProjectTranslations.FirstOrDefaultAsync(x => x.ProjectId == projectId
            && x.LanguageId == languageId);

            var categories = await(from c in _context.Categories
                                   join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                                   join pic in _context.ProjectInCategories on c.Id equals pic.CategoryId
                                   where pic.ProjectId == projectId && ct.LanguageId == languageId
                                   select ct.Name).ToListAsync();

            var image = await _context.ProjectImages.Where(x => x.ProjectId == projectId && x.IsDefault == true).FirstOrDefaultAsync();

            var productViewModel = new ProductVm()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                TotalArea=productTranslation.TotalArea,
                Location=productTranslation.Location,
                VacantArea=productTranslation.VacantArea,
                Area=productTranslation.Area,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                iframe=product.iframeMap,
                ViewCount = product.ViewCount,
                Technical=productTranslation.Technical,
                Commerce=productTranslation.Commerce,
                MainFunction1=productTranslation.MainFunction1,
                MainFunction2 = productTranslation.MainFunction2,
                MainFunction3 = productTranslation.MainFunction3,
                MainFunction4 = productTranslation.MainFunction4,
                Summary=productTranslation.Summary,
                AccessibilityPort=productTranslation.AccessibilityPort,
                AccessibilityExpressway=productTranslation.AccessibilityExpressway,
                AccessibilityAirport=productTranslation.AccessibilityAirport,
                AccessibilityCenter=productTranslation.AccessibilityCenter,
                Categories = categories,

                ThumbnailImage = image != null ? image.ImagePath : "no-image.jpg"
            };
            return productViewModel;
        }

        public async Task<ProjectImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProjectImages.FindAsync(imageId);
            if (image == null)
                throw new CncIndustrialException($"Cannot find an image with id {imageId}");

            var viewModel = new ProjectImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProjectId = image.ProjectId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }
        
        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var user = await _context.Projects.FindAsync(id);
            if (user == null)
            {
                return new ApiErrorResult<bool>($"Dự án với id {id} không tồn tại");
            }
            foreach (var category in request.Categories)
            {
                var productInCategory = await _context.ProjectInCategories
                    .FirstOrDefaultAsync(x => x.CategoryId == int.Parse(category.Id)
                    && x.ProjectId == id);
                if (productInCategory != null && category.Selected == false)
                {
                    _context.ProjectInCategories.Remove(productInCategory);
                }
                else if (productInCategory == null && category.Selected)
                {
                    await _context.ProjectInCategories.AddAsync(new ProjectInCategory()
                    {
                        CategoryId = int.Parse(category.Id),
                        ProjectId = id
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        //public async Task<PagedResult<ImageVm>> GetAllPagingImg(GetManageImagePagingRequest request)
        //{

        //    var query = from p in _context.Projects
        //                join pi in _context.ProjectImages on p.Id equals pi.ProjectId
        //                join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId

        //                select new {p, pt, pi };
        //    //2. filter
        //    //
        //    if (!string.IsNullOrEmpty(request.Keyword))
        //        query = query.Where(x => x.pt.Name.Contains(request.Keyword));



        //    //3. Paging
        //    int totalRow = await query.CountAsync();

        //    var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
        //        .Take(request.PageSize)
        //        .Select(x => new ImageVm()
        //        {
        //            Id = x.pi.Id,
        //            Caption = x.pi.Caption,
        //            DateCreated = x.pi.DateCreated,
        //            FileSize=x.pi.FileSize,
        //            ProjectId=x.pi.ProjectId,
        //            ImagePath=x.pi.ImagePath,
        //            NameProject=x.pt.Name 
        //        }).ToListAsync();

        //    //4. Select and projection
        //    var pagedResult = new PagedResult<ImageVm>()
        //    {
        //        TotalRecord = totalRow,
        //        PageSize = request.PageSize,
        //        PageIndex = request.PageIndex,
        //        Items = data
        //    };
        //    return pagedResult;


        //}
        public async Task<PagedResult<ImageVm>>GetAllPagingImg(GetManageImagePagingRequest request)
        {
            var query = _context.ProjectImages;
           //var query= from p in _context.Projects
           //           join pi in _context.ProjectImages on p.Id equals pi.ProjectId
           //           join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId
           //           where pi.ProjectId == pt.ProjectId 
           //           select new { p, pt, pi };
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ImageVm()
                {
                    //Id = x.pi.Id,
                    //Caption = x.pi.Caption,
                    //DateCreated = x.pi.DateCreated,
                    //FileSize = x.pi.FileSize,
                    //ProjectId = x.pi.ProjectId,
                    //ImagePath = x.pi.ImagePath,
                    //NameProject=x.pt.Name
                    Id = x.Id,
                    Caption = x.Caption,
                    DateCreated = x.DateCreated,
                    FileSize = x.FileSize,
                    ProjectId = x.ProjectId,
                    ImagePath = x.ImagePath
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ImageVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

      
    }
}
