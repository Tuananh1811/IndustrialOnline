using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.Employee;
using CncIndustrial.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CncIndustrial.AdminApp.Service
{
    public class EmployeeApiClient : BaseApiClient, IEmployeeApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public EmployeeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateEmp(EmployeeCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ImagePath != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImagePath.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImagePath.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImagePath", request.ImagePath.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PhoneNumber) ? "" : request.PhoneNumber.ToString()), "phoneNumber");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Position) ? "" : request.Position.ToString()), "position");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Introduce) ? "" : request.Introduce.ToString()), "introduce");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Email) ? "" : request.Email.ToString()), "email");
           
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/employees/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmp(int id)
        {
            return await Delete($"/api/employees/" + id);
        }

        public async Task<EmployeeVm> GetById(int id, string languageId)
        {
            var data = await GetAsync<EmployeeVm>($"/api/employees/{id}/{languageId}");

            return data;
        }

        public async Task<PagedResult<EmployeeVm>> GetPagings(GetManageEmployeePagingRequest request)
        {
            var data = await GetAsync<PagedResult<EmployeeVm>>(
                $"/api/Employees/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}");

            return data;
        }

        public async Task<bool> UpdateEmp(EmployeeUpdateRequest request)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ImagePath != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImagePath.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImagePath.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImagePath", request.ImagePath.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PhoneNumber) ? "" : request.PhoneNumber.ToString()), "phoneNumber");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Position) ? "" : request.Position.ToString()), "position");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Introduce) ? "" : request.Introduce.ToString()), "introduce");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Email) ? "" : request.Email.ToString()), "email");

            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PutAsync($"/api/employees/", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
