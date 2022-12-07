using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateProduct(ProjectCreateRequest request)
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

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
            }

            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");

           
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Area) ? "" : request.Area.ToString()), "area");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Location) ? "" : request.Location.ToString()), "location");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.iframeMap) ? "" : request.iframeMap.ToString()), "iframeMap");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.TotalArea) ? "" : request.TotalArea.ToString()), "totalArea");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.VacantArea) ? "" : request.VacantArea.ToString()), "vacantArea");
            
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction1) ? "" : request.MainFunction1.ToString()), "mainFunction1");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction2) ? "" : request.MainFunction2.ToString()), "mainFunction2");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction3) ? "" : request.MainFunction3.ToString()), "mainFunction3");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction4) ? "" : request.MainFunction4.ToString()), "mainFunction4");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Summary) ? "" : request.Summary.ToString()), "summary");
            
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.AccessibilityCenter) ? "" : request.AccessibilityCenter.ToString()), "accessibilityCenter");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.AccessibilityPort) ? "" : request.AccessibilityPort.ToString()), "accessibilityPort");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.AccessibilityAirport) ? "" : request.AccessibilityAirport.ToString()), "accessibilityAirport");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.AccessibilityExpressway) ? "" : request.AccessibilityExpressway.ToString()), "accessibilityExpressway");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Commerce) ? "" : request.Commerce.ToString()), "commerce");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Technical) ? "" : request.Technical.ToString()), "technical");



            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/projects/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProduct(ProjectUpdateRequest request)
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

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
            }

            //requestContent.Add(new StringContent(request.Id.ToString()), "id");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");


            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Area) ? "" : request.Area.ToString()), "area");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Location) ? "" : request.Location.ToString()), "location");

           
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.TotalArea) ? "" : request.TotalArea.ToString()), "totalArea");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.VacantArea) ? "" : request.VacantArea.ToString()), "vacantArea");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction1) ? "" : request.MainFunction1.ToString()), "mainFunction1");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction2) ? "" : request.MainFunction2.ToString()), "mainFunction2");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction3) ? "" : request.MainFunction3.ToString()), "mainFunction3");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MainFunction4) ? "" : request.MainFunction4.ToString()), "mainFunction4");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Summary) ? "" : request.Summary.ToString()), "summary");

            
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Commerce) ? "" : request.Commerce.ToString()), "commerce");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Technical) ? "" : request.Technical.ToString()), "technical");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PutAsync($"/api/projects/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>(
                $"/api/projects/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}&categoryId={request.CategoryId}");

            return data;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/projects/{id}/categories", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public async Task<ProductVm> GetById(int id, string languageId)
        {
            var data = await GetAsync<ProductVm>($"/api/projects/{id}/{languageId}");

            return data;
        }

        public async Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductVm>($"/api/projects/featured/{languageId}/{take}");
            return data;
        }

        public async Task<List<ProductVm>> GetLatestProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductVm>($"/api/projects/latest/{languageId}/{take}");
            return data;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await Delete($"/api/projects/" + id);
        }

      
    }
}
