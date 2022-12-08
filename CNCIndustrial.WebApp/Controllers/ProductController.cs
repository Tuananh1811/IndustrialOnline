using CncIndustrial.ApiIntegration;
using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Catalog.ProjectImages;
using CNCIndustrial.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCIndustrial.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly IImageApiClient _imageApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient, IImageApiClient imageApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
            _imageApiClient = imageApiClient;
        }

        public async Task<IActionResult> Detail(int id, string culture)
        {
            var product = await _productApiClient.GetById(id, culture);
           // var images = await _imageApiClient.GetListImagesProject(id);
            return View(new ProductDetailViewModel()
            {
                Product = product,
              ProductImages=await _imageApiClient.GetListImagesProject(id)

            }); ;
        }

        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {
            var products = await _productApiClient.GetPagings(new GetManageProductPagingRequest()
            {
                CategoryId = id,
                PageIndex = page,
                LanguageId = culture,
                PageSize = 10
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(culture, id),
                Products = products
            }); ;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
