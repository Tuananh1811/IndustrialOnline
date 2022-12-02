using CncIndustrial.AdminApp.Service;
using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.AdminApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageApiClient _iImageApiClient;
        private readonly IConfiguration _configuration;

        private readonly ICategoryApiClient _categoryApiClient;
        public ImageController(IImageApiClient imageApiClient,
            IConfiguration configuration
           )
        {
            _configuration = configuration;
            _iImageApiClient = imageApiClient;
            
        }
        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageImagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
               
            };
            var data = await _iImageApiClient.GetPagingsImage(request);
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
        public async Task<IActionResult> Create([FromForm] ProjectImageCreateRequest request,int projectId)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iImageApiClient.AddImageProject( projectId,request);
            if (result)
            {
                TempData["result"] = "Thêm mới ảnh thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm ảnh thất bại");
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, ImageVm request)
        {
            //  var projectId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var projectId = request.ProjectId;
            var product = await _iImageApiClient.GetById(id, projectId);
            var editVm = new ProjectImageUpdateRequest()
            {
                Id = product.Id,
                Caption = product.Caption,

            };
            return View(editVm);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProjectImageUpdateRequest request, int Id)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iImageApiClient.UpdateImageProject(Id, request );
            if (result)
            {
                TempData["result"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
            return View(request);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new ProjectImageDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request,int projectId)
        {
            if (!ModelState.IsValid)
                return View();
            
            var result = await _iImageApiClient.RemoveImageProject(request.Id,projectId);
            if (result)
            {
                TempData["result"] = "Xóa ảnh thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
