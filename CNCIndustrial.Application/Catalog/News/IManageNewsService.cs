using CncIndustrial.ViewModels.Catalog.News;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Catalog.News
{
   public interface IManageNewsService
    {

        Task<int> Create(NewsCreateRequest request);

        Task<int> Update(NewsUpdateRequest request);

        Task<int> Delete(int newsId);

        Task AddViewCount(int newsId);

        Task<PagedResult<NewsVm>> GetAllPaging(GetManageNewsPagingRequest request);

        Task<NewsVm> GetById(int newsId, string languageId);

    }
}
