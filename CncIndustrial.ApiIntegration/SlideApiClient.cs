using CncIndustrial.ViewModels.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
   public class SlideApiClient:BaseApiClient,ISlideApiClient
    {
        public SlideApiClient(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration)
           : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<SlideVm>> GetAll()
        {
            return await GetListAsync<SlideVm>("/api/slides");
        }
    }
}
