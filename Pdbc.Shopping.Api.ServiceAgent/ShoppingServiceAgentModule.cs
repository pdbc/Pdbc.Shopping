using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.Common;

namespace Pdbc.Shopping.Api.ServiceAgent
{
    public class ShoppingServiceAgentModule : IModule
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IShoppingApiServiceAgentConfiguration, ShoppingApiServiceAgentConfiguration>();

            serviceCollection.AddScoped<IErrorMessagesWebApiService, ErrorMessagesWebApiService>();
            serviceCollection.AddScoped<IHealthWebApiService, HealthWebApiService>();

            var config = new ShoppingApiServiceAgentConfiguration(configuration);
            serviceCollection.AddHttpClient(config.Name, c =>
            {
                c.BaseAddress = new Uri(config.BaseUrl);

                // Github API versioning
                //c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");

                // Github requires a user-agent
                //c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
        }

    }
}
