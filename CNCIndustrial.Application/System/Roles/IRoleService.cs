using CncIndustrial.ViewModels.System.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.System.Roles
{
   
        public interface IRoleService
        {
            Task<List<RoleVm>> GetAll();
        }
    
}
