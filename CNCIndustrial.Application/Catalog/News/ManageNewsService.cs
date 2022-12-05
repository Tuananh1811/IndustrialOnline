using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.News;
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

namespace CNCIndustrial.Application.Catalog.News
{
    public class ManageNewsService : IManageNewsService
    {
        private readonly CncIndustrialDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ManageNewsService(CncIndustrialDbContext context, IStorageService storageService)
        {

            _context = context;
            _storageService = storageService;
        }
        public async Task AddViewCount(int newsId)
        {
            var project = await _context.NewsPostIndustrials.FindAsync(newsId);
            project.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(NewsCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<NewsTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new NewsTranslation()
                    {
                        Title = request.Title,
                        Content = request.Content,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                       
                    });
                }
                else
                {
                    translations.Add(new NewsTranslation()
                    {
                        Title = SystemConstants.ProductConstants.NA,
                        Content = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
                        LanguageId = language.Id
                        
                    });
                }
            }
            var news = new NewsTable()
            {
                Title = request.Title,
                DescriShort = request.DescriShort,
               
                ViewCount = 0,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                NewsTranslations = translations,
                
            };
            if (request.HinhAnhMinhHoa != null)
            {
                news.HinhAnhMinhHoa = await this.SaveFile(request.HinhAnhMinhHoa);
               
            }
            _context.NewsPostIndustrials.Add(news);
            await _context.SaveChangesAsync();
            return news.Id;
        }

        public Task<int> Delete(int newsId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<NewsVm>> GetAllPaging(GetManageNewsPagingRequest request)
        {
            var query = _context.NewsPostIndustrials;
                       

            //2. filter
            //
            //if (!string.IsNullOrEmpty(request.Keyword))
            //    query = query.Where(x => x.Title.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new NewsVm()
                {
                    Id = x.Id,
                    Title = x.Title,
                    NgayTao =DateTime.Now,
                    DescriShort = x.DescriShort,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<NewsVm>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<NewsVm> GetById(int newsId, string languageId)
        {
            var newPost = await _context.NewsPostIndustrials.FindAsync(newsId);
            var newPostTranslation = await _context.NewsPostTranslations.FirstOrDefaultAsync(x => x.NewsTableId == newsId&&x.LanguageId==languageId);

            var image = await _context.NewsPostIndustrials.Where(x => x.Id == newsId).FirstOrDefaultAsync();

            var newsViewModel = new NewsVm()
            {
                Id = newPost.Id,
                NgayTao = newPost.NgayTao,
                DescriShort = newPost.DescriShort,
                LanguageId = newPostTranslation.LanguageId,
                Title = newPost.Title,
                SeoAlias = newPostTranslation.SeoAlias,
                SeoTitle = newPostTranslation.SeoTitle,              
                HinhAnhMinhHoa = image.HinhAnhMinhHoa
            };
            return newsViewModel;
        }

        public Task<int> Update(NewsUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

      
    }
}
