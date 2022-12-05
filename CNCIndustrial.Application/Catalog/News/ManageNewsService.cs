using CncIndustrial.Utilities.Constants;
using CncIndustrial.Utilities.Exceptions;
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
            var post = await _context.NewsPostIndustrials.FindAsync(newsId);
            post.ViewCount += 1;
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
                        DescriShort=request.DescriShort,
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

        public async Task<int> Delete(int newsId)
        {
            var post = await _context.NewsPostIndustrials.FindAsync(newsId);
            if (post == null) throw new CncIndustrialException($"Cannot find a news: {newsId}");

           
            _context.NewsPostIndustrials.Remove(post);

            return await _context.SaveChangesAsync();
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
                  NgayTao=x.NgayTao,
                    HinhAnhMinhHoa=x.HinhAnhMinhHoa
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
               
                LanguageId = newPostTranslation.LanguageId,
                Title = newPostTranslation.Title,
                SeoAlias = newPostTranslation.SeoAlias,
                SeoTitle = newPostTranslation.SeoTitle,              
                HinhAnhMinhHoa = image.HinhAnhMinhHoa,
                SeoDescription=newPostTranslation.SeoDescription,
            };
            return newsViewModel;
        }

        public async Task<int> Update(NewsUpdateRequest request)
        {
            var post = await _context.NewsPostIndustrials.FindAsync(request.Id);
            var postTranslations = await _context.NewsPostTranslations.FirstOrDefaultAsync(x => x.NewsTableId == request.Id
            && x.LanguageId == request.LanguageId);

            if (post == null || postTranslations == null) throw new CncIndustrialException($"Cannot find a news with id: {request.Id}");

            post.Title = request.Title;
            postTranslations.Title = request.Title;
            postTranslations.DescriShort = request.DescriShort;
            postTranslations.Content = request.Content;
            postTranslations.SeoTitle = request.SeoTitle;
            postTranslations.SeoAlias = request.SeoAlias;
            postTranslations.SeoDescription = request.SeoDescription;
            post.NgayCapNhat = DateTime.Now;
          
          
            //Save image
            if (request.HinhAnhMinhHoa != null)
            {
                post.HinhAnhMinhHoa = await this.SaveFile(request.HinhAnhMinhHoa);

            }

            return await _context.SaveChangesAsync();
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
