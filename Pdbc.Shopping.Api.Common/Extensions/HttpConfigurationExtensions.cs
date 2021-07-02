namespace Pdbc.Shopping.Api.Common.Extensions
{
    public static class HttpConfigurationExtensions
    {
        public static void RegisterGlobalFilters(this Microsoft.AspNetCore.Mvc.MvcOptions options)
        {
            //LogManager.GetLogger(typeof(HttpConfigurationExtensions)).Debug("Registering global filters for API");

            ////TODO NETCore - NoCacheHeaderFilter
            ////services.AddScoped<NoCacheHeaderFilter>();
            ////options.CacheProfiles.Add(new NoCacheHeaderProfile());

            //options.Filters.Add<RequestContextActionFilter>();
            //options.Filters.Add<EntityFrameworkTransactionActionFilter>();
            //options.Filters.Add<HttpResponseActionFilter>();
            //options.Filters.Add<FunctionalityExceptionFilter>();
        }
    }
}
