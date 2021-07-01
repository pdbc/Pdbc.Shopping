using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.Validation;

namespace Pdbc.Shopping.Core.CQRS
{
    public class GenericPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : new()
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ValidationBag _validationBag;

        public GenericPipelineBehavior(IServiceProvider serviceProvider, ValidationBag validationBag)
        {
            _serviceProvider = serviceProvider;
            _validationBag = validationBag;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IQuery query)
            {
                return await ExecuteQuery(request, cancellationToken, next);
            }
            else if (request is ICommand command)
            {
                return await ExecuteCommand(request, cancellationToken, next);
            }
            else
            {
                return await ExecuteOther(request, cancellationToken, next);
            }

        }

        private async Task<TResponse> ExecuteQuery(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            await PerformValidation(request);
            if (_validationBag.HasErrors())
            {
                var r = new TResponse();
                return r;
            }

            var response = await next();
            return response;
        }

        private async Task PerformValidation(TRequest request)
        {
            // Validation
            var validators = _serviceProvider.GetServices(typeof(IValidationBagValidator<TRequest>));
            foreach (IValidationBagValidator<TRequest> validator in validators)
            {
                await validator.Validate(request, _validationBag);
            }
        }

        private async Task<TResponse> ExecuteCommand(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            await PerformValidation(request);

            var response = await next();
            return response;
        }

        private async Task<TResponse> ExecuteOther(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            return response;
        }
    }


}
