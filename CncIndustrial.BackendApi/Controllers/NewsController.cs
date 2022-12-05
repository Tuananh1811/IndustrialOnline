using CncIndustrial.ViewModels.Catalog.News;
using CNCIndustrial.Application.Catalog.News;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IManageNewsService _newsService;
        public NewsController(IManageNewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet("{newsId}/{languageId}")]
        public async Task<IActionResult> GetById(int newsId, string languageId)
        {
            var newPost = await _newsService.GetById(newsId, languageId);
            if (newPost == null)
                return BadRequest("Cannot find product");
            return Ok(newPost);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] NewsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newsId = await _newsService.Create(request);
            if (newsId == 0)
                return BadRequest();

            var newPost = await _newsService.GetById(newsId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = newsId }, newPost);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageNewsPagingRequest request)
        {
            var products = await _newsService.GetAllPaging(request);
            return Ok(products);
        }
    }
}
