using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Common;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Services.Cqrs
{
    public class MusicCqrsServicesModule : IModule
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {

            //// Scan register 
            serviceCollection.Scan(scan => scan.FromAssemblyOf<MusicCqrsServicesModule>()
                .AddClasses(true)  // Get all classes implementing the IValidator<T>
                .AsMatchingInterface()
                .WithScopedLifetime()
            );


            serviceCollection.AddScoped<IErrorMessagesCqrsService, ErrorMessagesCqrsService>();
            serviceCollection.AddScoped<IErrorMessagesService, ErrorMessagesCqrsService>();
        }
    
    }
}
