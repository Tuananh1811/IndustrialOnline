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
    }
}
