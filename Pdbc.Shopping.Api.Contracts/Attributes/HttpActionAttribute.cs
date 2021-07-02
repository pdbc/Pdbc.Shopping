using System;
using Pdbc.Shopping.Api.Contracts.Enum;

namespace Pdbc.Shopping.Api.Contracts.Attributes
{
    /// <summary>
    /// Attribute to signal Typewriter information on classes
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class HttpActionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpActionAttribute"/> class.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        public HttpActionAttribute(string route, Method httpMethod)
        {
            Route = route;
            HttpMethod = httpMethod;
        }

        /// <summary>
        /// Gets the route.
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public string Route { get; }
        /// <summary>
        /// Gets the HTTP method.
        /// </summary>
        /// <value>
        /// The HTTP method.
        /// </value>
        public Method HttpMethod { get; }
    }
}
