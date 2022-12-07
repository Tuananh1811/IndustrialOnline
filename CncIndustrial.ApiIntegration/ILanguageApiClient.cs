using CncIndustrial.ViewModels.Common;
using CncIndustrial.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}
