using CncIndustrial.ViewModels.Catalog.Employee;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
  public  interface IEmployeeApiClient
    {
        Task<PagedResult<EmployeeVm>> GetPagings(GetManageEmployeePagingRequest request);

        Task<bool> CreateEmp(EmployeeCreateRequest request);

        Task<bool> UpdateEmp(EmployeeUpdateRequest request);

        Task<bool> DeleteEmp(int id);

        Task<EmployeeVm> GetById(int id, string languageId);

     
    }
}
