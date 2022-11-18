using CncIndustrial.Utilities.Constants;
using CncIndustrial.Utilities.Exceptions;
using CncIndustrial.ViewModels.Catalog.ProductImages;
using CncIndustrial.ViewModels.Catalog.Project.Manage;
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
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    });
                }
                else
                {
                    translations.Add(new ProjectTranslation()
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        Description = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
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
          return  await _context.SaveChangesAsync();
           // return product.Id;

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
       
       

        public async Task<PagedResult<ProductVm>> GetAllPaging(GetProjectPagingRequest request)
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
            if (!string.IsNullOrEmpty(request.Keywork))
                query = query.Where(x => x.pt.Name.Contains(request.Keywork));

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
                    Details = x.pt.Details,
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
            productTranslations.Details = request.Details;

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
        /*
         * 
         */
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
                        && p.IsFeatured == true
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
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
                    Details = x.pt.Details,
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

            return data;
        }
    }
}
