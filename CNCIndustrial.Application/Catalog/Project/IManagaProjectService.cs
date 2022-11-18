using CncIndustrial.ViewModels.Catalog.ProductImages;
using CncIndustrial.ViewModels.Catalog.Project.Manage;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
using CncIndustrial.ViewModels.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Catalog.Project
{
    public  interface IManagaProjectService
    {
        Task<int> Create(ProjectCreateRequest request);

        Task<int> Update(ProjectUpdateRequest request);

        Task<int> Delete(int projectId);

        Task AddViewCount(int projectId);
       
       Task<PagedResult<ProductVm>> GetAllPaging(GetProjectPagingRequest request);

        Task<int> AddImage(int projectId, ProjectImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProjectImageUpdateRequest request);

        Task<ProjectImageViewModel> GetImageById(int imageId);

        Task<List<ProjectImageViewModel>> GetListImages(int productId);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);
    }
}
