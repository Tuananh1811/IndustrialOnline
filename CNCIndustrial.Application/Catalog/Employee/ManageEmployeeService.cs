using CncIndustrial.Utilities.Constants;
using CncIndustrial.Utilities.Exceptions;
using CncIndustrial.ViewModels.Catalog.Employee;
using CncIndustrial.ViewModels.Common;
using CNCIndustrial.Application.Common;
using CNCIndustrial.Data.EF;
using CNCIndustrial.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Catalog.Employee
{
    public class ManageEmployeeService : IManageEmployeeService
    {
        private readonly CncIndustrialDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ManageEmployeeService(CncIndustrialDbContext context, IStorageService storageService)
        {

            _context = context;
            _storageService = storageService;
        }
       

        public  async Task<int> Create(EmployeeCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<EmployeeTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new EmployeeTranslation()
                    {
                        Name = request.Name,
                        Introduce = request.Introduce,
                        Position = request.Position,
                        LanguageId = request.LanguageId,
                       

                    });
                }
                else
                {
                    translations.Add(new EmployeeTranslation()
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        Introduce = SystemConstants.ProductConstants.NA,
                        Position = SystemConstants.ProductConstants.NA,
                        LanguageId = language.Id

                    });
                }
            }
            var employees = new EmployeeUser()
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                EmployeeTranslations= translations
            };
            if (request.ImagePath != null)
            {
                employees.ImagePath = await this.SaveFile(request.ImagePath);

            }
            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();
            return employees.Id;

        }

        public async Task<int> Delete(int newsId)
        {
            var emp = await _context.Employees.FindAsync(newsId);
            if (emp == null) throw new CncIndustrialException($"Cannot find a Employee: {newsId}");

            _context.Employees.Remove(emp);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<EmployeeVm>> GetAllPaging(GetManageEmployeePagingRequest request)
        {
            var query = from e in _context.Employees
                        join et in _context.EmployeeTranslations on e.Id equals et.EmployeeId
                        where et.LanguageId=="vi"
                        select new { e,et};
            //2. filter
            //
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.et.Name.Contains(request.Keyword));


            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new EmployeeVm()
                {
                    Id = x.e.Id,
                    
                    Name = x.et.Name,
                    Email=x.e.Email,
                    Introduce=x.et.Introduce,
                    PhoneNumber=x.e.PhoneNumber,
                    Position=x.et.Position,
                    LanguageId=x.et.LanguageId,
                    ImagePath = x.e.ImagePath
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<EmployeeVm>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<EmployeeVm> GetById(int employeeId, string languageId)
        {
            var newEmployee = await _context.Employees.FindAsync(employeeId);
            var newEmployeeTranslation = await _context.EmployeeTranslations.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.LanguageId == languageId);

            var image = await _context.Employees.Where(x => x.Id == employeeId).FirstOrDefaultAsync();

            var newsViewModel = new EmployeeVm()
            {
                Id = newEmployee.Id,
                LanguageId = newEmployeeTranslation.LanguageId,
                Name = newEmployeeTranslation.Name,
                Position=newEmployeeTranslation.Position,
                PhoneNumber=newEmployee.PhoneNumber,
                Email=newEmployee.Email,
                Introduce=newEmployeeTranslation.Introduce,
                ImagePath = image.ImagePath,
                
            };
            return newsViewModel;
        }

        public async Task<int> Update(EmployeeUpdateRequest request)
        {
            var emp = await _context.Employees.FindAsync(request.Id);
            var empTranslations = await _context.EmployeeTranslations.FirstOrDefaultAsync(x => x.EmployeeId == request.Id
            && x.LanguageId == request.LanguageId);

            if (emp == null || empTranslations == null) throw new CncIndustrialException($"Cannot find a employee with id: {request.Id}");

            empTranslations.Name = request.Name;
            empTranslations.Position = request.Position;
            empTranslations.Introduce = request.Introduce;
            emp.Email = request.Email;
            emp.PhoneNumber = request.PhoneNumber;
          
            //Save image
            if (request.ImagePath != null)
            {
                emp.ImagePath = await this.SaveFile(request.ImagePath);

            }

            return await _context.SaveChangesAsync();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
