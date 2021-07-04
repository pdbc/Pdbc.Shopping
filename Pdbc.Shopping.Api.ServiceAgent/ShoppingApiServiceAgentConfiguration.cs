using System;
using Microsoft.Extensions.Configuration;

namespace Pdbc.Shopping.Api.ServiceAgent
{
    /// <summary>
    /// Configuration to configure the connection with the Music API
    /// </summary>
    public interface IShoppingApiServiceAgentConfiguration
    {
        /// <summary>
        /// Name of the HttpClient
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// Gets the base URL for the Functionality Domain API
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        String BaseUrl { get; }

    }

    /// <inheritdoc />
    public class ShoppingApiServiceAgentConfiguration : IShoppingApiServiceAgentConfiguration
    {
        /// <summary>
        /// Constructor for the configuration
        /// </summary>
        /// <param name="configuration"></param>
        public ShoppingApiServiceAgentConfiguration(IConfiguration configuration)
        {
            configuration.GetSection("serviceagent:musicApi").Bind(this);
        }

        public string Name { get; set; }

        /// <inheritdoc />
        public string BaseUrl { get; set; }

    }
}