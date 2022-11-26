using CncIndustrial.ViewModels.Common;
using CncIndustrial.ViewModels.System.Languages;
using CNCIndustrial.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.System.Languages
{
   public class LanguageService:ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly CncIndustrialDbContext _context;

        public LanguageService(CncIndustrialDbContext context,
            IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name,
                IsDefault = x.IsDefault
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }

        
    }
}
