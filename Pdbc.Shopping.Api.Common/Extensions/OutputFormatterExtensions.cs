using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Pdbc.Shopping.Api.Common.Extensions
{
    public static class OutputFormatterExtensions
    {
        public static void SetOutputFormatters(this MvcOptions options)
        {
            options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

            //var jsonOutputFormatter = options.OutputFormatters
            //    .OfType<Microsoft.AspNetCore.Mvc.Formatters.Json.JsonOutputFormatter>().FirstOrDefault();

            //if (jsonOutputFormatter != null)
            //{
            //    // remove text/json as it isn't the approved media type
            //    // for working with JSON at API level
            //    if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
            //    {
            //        jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
            //    }
            //}
        }
    }
}