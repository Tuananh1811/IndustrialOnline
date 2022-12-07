using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
using CNCIndustrial.Application.Catalog.Project;
using Microsoft.AspNetCore.Authorization;
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
    public class ProjectsController : ControllerBase
    {
        private readonly IManagaProjectService _projectService;
       
        public ProjectsController(IManagaProjectService productService)
        {
            _projectService = productService;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _projectService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpGet("pagingImg")]
        public async Task<IActionResult> GetAllPagingImg([FromQuery] GetManageImagePagingRequest request)
        {
            var images = await _projectService.GetAllPagingImg(request);
            return Ok(images);
        }
        [HttpGet("{projectId}/{languageId}")]
        public async Task<IActionResult> GetByIdPro(int projectId, string languageId)
        {
            var product = await _projectService.GetByIdPro(projectId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpGet("featured/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(int take, string languageId)
        {
            var products = await _projectService.GetFeaturedProducts(languageId, take);
            return Ok(products);
        }

        [HttpGet("latest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(int take, string languageId)
        {
            var products = await _projectService.GetLatestProducts(languageId, take);
            return Ok(products);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProjectCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projectId = await _projectService.Create(request);
            if (projectId == 0)
                return BadRequest();

            var project = await _projectService.GetByIdPro(projectId, request.LanguageId);

            return CreatedAtAction(nameof(GetByIdPro), new { id = projectId }, project);
        }

        [HttpPut("{projectId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int projectId, [FromForm] ProjectUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = projectId;
            var affectedResult = await _projectService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(int projectId)
        {
            var affectedResult = await _projectService.Delete(projectId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPost("{productId}/images")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProjectImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _projectService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _projectService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }
        [HttpPut("{productId}/images/{imageId}")]
      //  [Authorize]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProjectImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _projectService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _projectService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }
        [HttpDelete("{productId}/images/{imageId}")]
       // [Authorize]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _projectService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpPut("{id}/categories")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
    }
}
