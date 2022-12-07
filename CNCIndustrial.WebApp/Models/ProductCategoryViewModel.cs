using CncIndustrial.ViewModels.Catalog.Categories;
using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCIndustrial.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}
