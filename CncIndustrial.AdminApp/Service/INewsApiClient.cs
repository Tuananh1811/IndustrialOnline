using CncIndustrial.ViewModels.Catalog.News;
using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.AdminApp.Service
{
    public interface INewsApiClient
    {
        Task<PagedResult<NewsVm>> GetPagings(GetManageNewsPagingRequest request);

        Task<bool> CreatePost(NewsCreateRequest request);

        Task<bool> UpdatePost(NewsUpdateRequest request);

        Task<bool> DeleteNews(int id);

        Task<NewsVm> GetById(int id, string languageId);

        Task<List<NewsVm>> GetFeaturedNews(string languageId, int take);

        Task<List<NewsVm>> GetLatestNews(string languageId, int take);

     
    }
}
