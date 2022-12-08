using CncIndustrial.ViewModels.Catalog.ProductImages;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
  public  interface IImageApiClient
    {
        Task<PagedResult<ImageVm>> GetPagingsImage(GetManageImagePagingRequest request);

        Task<List<ImageVm>> GetListImagesProject(int productId);

        Task<bool> AddImageProject(int projectId, ProjectImageCreateRequest request);

        Task<bool> RemoveImageProject(int imageId, int projectId);

        Task<bool> UpdateImageProject(int imageId, ProjectImageUpdateRequest request);

        Task<ImageVm> GetById(int id, int projectId);
    }
}
