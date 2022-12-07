using CncIndustrial.Utilities.Constants;
using CncIndustrial.ViewModels.Catalog.News;

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
    public class NewsApiClient : BaseApiClient, INewsApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public NewsApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreatePost(NewsCreateRequest request)
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

            if (request.HinhAnhMinhHoa != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.HinhAnhMinhHoa.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.HinhAnhMinhHoa.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "HinhAnhMinhHoa", request.HinhAnhMinhHoa.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Title) ? "" : request.Title.ToString()), "title");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content.ToString()), "content");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.DescriShort) ? "" : request.DescriShort.ToString()), "descriShort");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/news/", requestContent);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteNews(int id)
        {
            return await Delete($"/api/news/" + id);
        }

        public async Task<NewsVm> GetById(int id, string languageId)
        {
            var data = await GetAsync<NewsVm>($"/api/news/{id}/{languageId}");

            return data;
        }

        public Task<List<NewsVm>> GetFeaturedNews(string languageId, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsVm>> GetLatestNews(string languageId, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<NewsVm>> GetPagings(GetManageNewsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<NewsVm>>(
                $"/api/News/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}");

            return data;
        }

        public async Task<bool> UpdatePost(NewsUpdateRequest request)
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

            if (request.HinhAnhMinhHoa != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.HinhAnhMinhHoa.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.HinhAnhMinhHoa.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "HinhAnhMinhHoa", request.HinhAnhMinhHoa.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Title) ? "" : request.Title.ToString()), "title");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content.ToString()), "content");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.DescriShort) ? "" : request.DescriShort.ToString()), "descriShort");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PutAsync($"/api/news/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
