using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Common;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS;

namespace Pdbc.Shopping.Core
{
    public class ShoppingCoreModule : IModule
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMediatR(typeof(ShoppingCoreModule));

            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(GenericPipelineBehavior<,>));
            //serviceCollection.AddScoped(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));
            //serviceCollection.AddScoped(typeof(IRequestPostProcessor<,>), typeof(GenericRequestPostProcessor<,>));

            serviceCollection.AddScoped<ValidationBag>();

            // Scan register all validators
            serviceCollection.Scan(scan => scan.FromAssemblyOf<ShoppingCoreModule>()
                .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)).Where(_ => !_.IsGenericType))  // Get all classes implementing the IValidator<T>
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            serviceCollection.Scan(scan => scan.FromAssemblyOf<ShoppingCoreModule>()
                .AddClasses(classes => classes.AssignableTo(typeof(IFactory<,>)).Where(_ => !_.IsGenericType))  // Get all classes implementing the IValidator<T>
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            serviceCollection.Scan(scan => scan.FromAssemblyOf<ShoppingCoreModule>()
                .AddClasses(classes => classes.AssignableTo(typeof(IChangesHandler<,>)).Where(_ => !_.IsGenericType))  // Get all classes implementing the IValidator<T>
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
        }
    }
}
