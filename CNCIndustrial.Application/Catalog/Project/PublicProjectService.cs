using CNCIndustrial.Application.Common;

using CNCIndustrial.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CncIndustrial.ViewModels.Common;
using CncIndustrial.ViewModels.Catalog.Project;

namespace CNCIndustrial.Application.Catalog.Project
{
    public class PublicProjectService : IPublicProject
    {
        private readonly CncIndustrialDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public PublicProjectService(CncIndustrialDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<PagedResult<ProjectViewModel>> GetAllByCategoryId(GetProjectPagingRequest request)
        {
            var query = from p in _context.Projects
                        join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId
                        join pic in _context.ProjectInCategories on p.Id equals pic.ProjectId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProjectImages on p.Id equals pi.ProjectId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId && pi.IsDefault == true
                        select new { p, pt, pic,pi };
            //2. filter
            //
            if (request.categoryId.HasValue && request.categoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.categoryId);
            }
                //query = query.Where(x => x.pt.Name.Contains(request.Keywork));

            //if (request.CategoryId != null && request.CategoryId != 0)
            //{
            //    query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            //}

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProjectViewModel()
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
            var pagedResult = new PagedResult<ProjectViewModel>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<List<ProjectViewModel>> GetAll()
        {
            var query = from p in _context.Projects
                        join pt in _context.ProjectTranslations on p.Id equals pt.ProjectId
                        join pic in _context.ProjectInCategories on p.Id equals pic.ProjectId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        //into picc
                        //from c in picc.DefaultIfEmpty()
                        //join pi in _context.ProjectImages on p.Id equals pi.ProjectId into ppi
                        //from pi in ppi.DefaultIfEmpty()
                        //where pt.LanguageId == request.LanguageId && pi.IsDefault == true
                        select new { p, pt, pic };
            var data = await query
               .Select(x => new ProjectViewModel()
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
                  
               }).ToListAsync();
            return data;

        }
    }
}
