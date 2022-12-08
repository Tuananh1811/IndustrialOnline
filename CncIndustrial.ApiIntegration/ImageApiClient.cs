using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.ProductImages;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
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
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
    public class ImageApiClient : BaseApiClient, IImageApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ImageApiClient(IHttpClientFactory httpClientFactory,
                     IHttpContextAccessor httpContextAccessor,
                      IConfiguration configuration)
              : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                    typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
        public async Task<bool> AddImageProject(int projectId, ProjectImageCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            //var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
           
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }
            requestContent.Add(new StringContent(request.SortOrder.ToString()), "sortOrder");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Caption) ? "" : request.Caption.ToString()), "caption");
           


            var response = await client.PostAsync($"/api/projects/{projectId}/images", requestContent);
            return response.IsSuccessStatusCode;

        }

        public async Task<List<ImageVm>> GetListImagesProject(int productId)
        {
            var data = await GetAsync<List<ImageVm>>($"/api/projects/{productId}/images");
            return data;
           
        }

        public async Task<PagedResult<ImageVm>> GetPagingsImage(GetManageImagePagingRequest request)
        {
            var data = await GetAsync<PagedResult<ImageVm>>($"/api/projects/pagingImg?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            return data;
        }

      

        public async Task<bool> UpdateImageProject(int imageId, ProjectImageUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            //var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }
            requestContent.Add(new StringContent(request.SortOrder.ToString()), "sortOrder");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Caption) ? "" : request.Caption.ToString()), "caption");
            



            var response = await client.PutAsync($"/api/projects/{request.Id}/images/"+ imageId, requestContent);
            return response.IsSuccessStatusCode;
        }
        public async Task<ImageVm> GetById(int id,int projectId )
        {
            var data = await GetAsync<ImageVm>($"/api/projects/{projectId}/images/{id}");

            return data;
        }
        public async Task<bool> RemoveImageProject(int imageId,int projectId)
        {
            //productId}/images/{imageId}
            return await Delete($"/api/projects/{projectId}/images/" + imageId);
        }

    }
}
