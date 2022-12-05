using CncIndustrial.ViewModels.Catalog.Employee;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Catalog.Employee
{
   public interface IManageEmployeeService
    {
        Task<int> Create(EmployeeCreateRequest request);

        Task<int> Update(EmployeeUpdateRequest request);

        Task<int> Delete(int newsId);

        Task<PagedResult<EmployeeVm>> GetAllPaging(GetManageEmployeePagingRequest request);

        Task<EmployeeVm> GetById(int employeeId, string languageId);
    }
}
