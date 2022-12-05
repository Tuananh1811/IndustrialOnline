using CncIndustrial.ViewModels.Catalog.Employee;
using CNCIndustrial.Application.Catalog.Employee;
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
    public class EmployeesController : ControllerBase
    {
        private readonly IManageEmployeeService _employeeService;
        public EmployeesController(IManageEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{employeeId}/{languageId}")]
        public async Task<IActionResult> GetById(int employeeId, string languageId)
        {
            var newEmployee = await _employeeService.GetById(employeeId, languageId);
            if (newEmployee == null)
                return BadRequest("Cannot find product");
            return Ok(newEmployee);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newsId = await _employeeService.Create(request);
            if (newsId == 0)
                return BadRequest();

            var newPost = await _employeeService.GetById(newsId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = newsId }, newPost);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageEmployeePagingRequest request)
        {
            var products = await _employeeService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpPut("{employeeId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int employeeId, [FromForm] EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = employeeId;
            var affectedResult = await _employeeService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var affectedResult = await _employeeService.Delete(employeeId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
