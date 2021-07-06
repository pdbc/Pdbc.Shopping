using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Common.Extensions;
using Pdbc.Shopping.Core;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Services.Cqrs;

namespace Pdbc.Shopping.IntegrationTests.Cqrs
{
    public class ShoppingIntegrationTestBootstrap
    {
        public static void BootstrapContainer(IServiceCollection services, 
                                              IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(RequestToCqrsMappings));
            
            services.RegisterModule<ShoppingCoreModule>(configuration);
            services.RegisterModule<ShoppingCqrsServicesModule>(configuration);
            services.RegisterModule<ShoppingDataModule>(configuration);
        }
    }
}
