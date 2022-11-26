using CncIndustrial.ViewModels.Common;
using CncIndustrial.ViewModels.System.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.AdminApp.Service
{
   public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}
