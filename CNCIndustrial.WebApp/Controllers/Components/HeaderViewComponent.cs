using CncIndustrial.ApiIntegration;
using CncIndustrial.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CNCIndustrial.WebApp.Controllers.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public HeaderViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View(items);
        }
    }
}
