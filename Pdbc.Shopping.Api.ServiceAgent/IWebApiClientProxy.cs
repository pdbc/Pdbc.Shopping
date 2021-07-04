using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pdbc.Shopping.Api.ServiceAgent
{
    /// <summary>
    /// Interface defining the proxy methods used to communicate with a web api.
    /// </summary>
    public interface IWebApiClientProxy
    {
        /// <summary>
        /// Gets the timeout to wait before the request times out.
        /// </summary>
        TimeSpan ClientTimeout { get; }

        /// <summary>
        /// Posts to the WebApi service method the JSON-formatted TRequest.
        /// If response indicates a Succes or Validation status, returns the response read as TResponse.
        /// Throws an Exception with the stringified response if other HTTP status code returned.
        /// </summary>
        Task<TResponse> PostAsync<TRequest, TResponse>(string method, TRequest request);

        /// <summary>
        /// Puts to the WebApi service method the JSON-formatted TRequest.
        /// If response indicates a Succes or Validation status, returns the response read as TResponse.
        /// Throws an Exception with the stringified response if other HTTP status code returned.
        /// </summary>
        Task<TResponse> PutAsync<TRequest, TResponse>(string method, TRequest request);

        /// <summary>
        /// Calls the WebApi service with whatever HttpClient call you provide.
        /// </summary>
        Task<TResponse> CallAsync<TResponse>(Func<HttpClient, Task<TResponse>> httpClientCall);
    }
}