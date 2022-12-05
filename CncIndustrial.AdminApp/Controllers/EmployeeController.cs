using CncIndustrial.AdminApp.Service;
using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.AdminApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApiClient _employeeApiClient;
        private readonly IConfiguration _configuration;

        public EmployeeController(IEmployeeApiClient employeeApiClient, IConfiguration configuration
           )
        {
            _configuration = configuration;
            _employeeApiClient = employeeApiClient;

        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageEmployeePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,

            };
            var data = await _employeeApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;



            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _employeeApiClient.CreateEmp(request);
            if (result)
            {
                TempData["result"] = "Thêm mới nhân viên thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm nhân viên thất bại");
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var post = await _employeeApiClient.GetById(id, languageId);
            var editVm = new EmployeeUpdateRequest()
            {
                Id = post.Id,

                Name = post.Name,
                Email = post.Email,
                Introduce = post.Introduce,
                PhoneNumber = post.PhoneNumber,
                Position = post.Position,
               

            };
            return View(editVm);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _employeeApiClient.UpdateEmp(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thông tin thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thông tin thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var result = await _employeeApiClient.GetById(id, languageId);
            var editVm = new EmployeeVm()
            {
                Id = result.Id,
               Email=result.Email,
               Name=result.Name,
               Introduce=result.Introduce,
               PhoneNumber=result.PhoneNumber,
               Position=result.Position

            };
            return View(editVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new EmployeeDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _employeeApiClient.DeleteEmp(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa nhân viên thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }

    }
}
