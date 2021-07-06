using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pdbc.Shopping.Api.Common.Attributes;

namespace Pdbc.Shopping.Api.Common.Extensions
{
    public static class ActionResultExtensions
    {
        public static void SetInvalidModelStateResponse(this ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var actionExecutingContext = actionContext as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

                if (actionContext.ModelState.ErrorCount > 0
                    && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                {
                    return new UnprocessableEntityObjectResult(actionContext.ModelState);
                }

                return new BadRequestObjectResult(actionContext.ModelState);
            };
        }
    }

    public static class ActionContextExtensions
    {
        /// <summary>
        /// Skips the entity framework transaction action filter.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static long GetTimeoutSettingsForOperation(this ActionExecutingContext actionContext, long defaultTimeout)
        {
            if (actionContext == null)
                return defaultTimeout;

            var attributes = actionContext.ActionDescriptor.EndpointMetadata.OfType<ActionTimeoutAttribute>().ToList();
            if (attributes.Any())
            {
                var timeoutAttribute = attributes.FirstOrDefault();
                return timeoutAttribute?.Timeout ?? defaultTimeout;
            }

            return defaultTimeout;
        }
    }
}