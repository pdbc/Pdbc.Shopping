using Microsoft.AspNetCore.Mvc;

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
}