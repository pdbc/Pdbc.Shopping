using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Pdbc.Shopping.Api.Common.Extensions
{
    public static class ApiVersionExtensions
    {

        public static void SetVersionApiExplorer(this ApiExplorerOptions options)
        {
            options.GroupNameFormat = "'v'VV";
        }

        public static void SetVersion(this ApiVersioningOptions options)
        {

            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            //setupAction.ApiVersionReader = new HeaderApiVersionReader("api-version");
            //setupAction.ApiVersionReader = new MediaTypeApiVersionReader();

        }
    }
}