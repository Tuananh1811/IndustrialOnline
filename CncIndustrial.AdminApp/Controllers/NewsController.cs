using CncIndustrial.AdminApp.Service;
using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.News;
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
    public class NewsController : Controller
    {
        private readonly INewsApiClient _newsApiClient;
        private readonly IConfiguration _configuration;

        private readonly ICategoryApiClient _categoryApiClient;
        public NewsController(INewsApiClient newsApiClient,
            IConfiguration configuration
           )
        {
            _configuration = configuration;
            _newsApiClient = newsApiClient;
           
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageNewsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
                
            };
            var data = await _newsApiClient.GetPagings(request);
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
        public async Task<IActionResult> Create([FromForm] NewsCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _newsApiClient.CreatePost(request);
            if (result)
            {
                TempData["result"] = "Thêm mới tin tức thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm tin tức thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var post = await _newsApiClient.GetById(id, languageId);
            var editVm = new NewsUpdateRequest()
            {
                Id = post.Id,
               CreateDate=(DateTime)post.NgayTao,
                Title = post.Title,
                
            };
            return View(editVm);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] NewsUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _newsApiClient.UpdatePost(request);
            if (result)
            {
                TempData["result"] = "Cập nhật tin tức thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật tin tức thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var result = await _newsApiClient.GetById(id,languageId);
            var editVm = new NewsVm()
            {
                Id = result.Id,
                NgayTao = (DateTime)result.NgayTao,
                Title = result.Title,
                DescriShort = result.DescriShort,
                SeoTitle=result.SeoTitle,
                SeoAlias=result.SeoAlias

            };
            return View(editVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new NewsDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewsDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _newsApiClient.DeleteNews(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa tin tức thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }

    }
}
