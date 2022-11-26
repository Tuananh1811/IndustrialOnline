using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Catalog.Project
{
    public  interface IPublicProject
    {
       Task<PagedResult<ProjectViewModel>>  GetAllByCategoryId( GetProjectPagingRequest request);
        Task<List<ProjectViewModel>> GetAll();
    }
}
