using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.Common.Extensions;
using Pdbc.Shopping.Common.Validation;

namespace Pdbc.Shopping.Api.Common.ActionFilters
{
    /// <summary>
    /// Action filter responsible for handling transactions through the entire request pipeline
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    public class TransactionActionFilter : ActionFilterAttribute
    {
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var serviceProvider = actionContext.HttpContext.RequestServices;


            var validationBag = serviceProvider.GetService<ValidationBag>();

            var transactionTimeoutInSeconds = actionContext.GetTimeoutSettingsForOperation(10);

            var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(transactionTimeoutInSeconds)
                }, TransactionScopeAsyncFlowOption.Enabled);

            actionContext.HttpContext.Items.Add("TransactionActionFilter.Transaction", transactionScope);

            base.OnActionExecuting(actionContext);
        }

        /// <inheritdoc />
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {

            try
            {
                base.OnActionExecuted(actionExecutedContext);
            }
            finally
            {
                var serviceProvider = actionExecutedContext.HttpContext.RequestServices;
                var validationBag = serviceProvider.GetService<ValidationBag>();

                var transactionScope = (TransactionScope)actionExecutedContext.HttpContext.Items["TransactionActionFilter.Transaction"];

                if (actionExecutedContext.Exception != null)
                {
                    transactionScope.Dispose();
                }
                else if (validationBag.HasErrors())
                {
                    transactionScope.Dispose();
                }
                else
                {
                    transactionScope.Complete();
                }
            }
        }

    }
}
