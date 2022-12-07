using CncIndustrial.ViewModels.Common;
using CncIndustrial.ViewModels.System.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
   public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}
