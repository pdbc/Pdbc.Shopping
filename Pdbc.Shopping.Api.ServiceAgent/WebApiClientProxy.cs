using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.ServiceAgent.Extensions;

namespace Pdbc.Shopping.Api.ServiceAgent
{
    /// <summary>
    /// Basic WebApi Client proxy via .NET HttpClient, allowing type casts of the request/response to contract entities
    /// </summary>
    public class WebApiClientProxy
    {
        private readonly string _name;
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Gets or sets the timeout to wait before the request times out.
        /// </summary>
        public TimeSpan ClientTimeout { get; private set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public WebApiClientProxy(IHttpClientFactory factory, String name, int timeoutInMilliseconds = 5 * 1000)
        {
            _httpClientFactory = factory;
            _name = name;
            ClientTimeout = TimeSpan.FromMilliseconds(timeoutInMilliseconds);
        }

        /// <summary>
        /// The HttpClient responsible for sending/receiving HTTP requests and responses.
        /// </summary>
        /// <returns></returns>
        protected virtual HttpClient GetHttpClient()
        {
            var client = _httpClientFactory.CreateClient(_name);

            // Request response in json
            client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.T

            return client;
        }

        /// <summary>
        /// Posts to the WebApi service route the JSON-formatted TRequest.
        /// If response indicates a Success or Validation status, returns the response read as TResponse.
        /// Throws an Exception with the stringified response if other HTTP status code returned.
        /// </summary>
        public virtual Task<TResponse> PostAsync<TRequest, TResponse>(string route, TRequest request)
        {
            return RequestAsync<TResponse>(GetHttpClient().PostAsJsonAsync(route, request));
        }

        /// <summary>
        /// Puts to the WebApi service route the JSON-formatted TRequest.
        /// If response indicates a Succes or Validation status, returns the response read as TResponse.
        /// Throws an Exception with the stringified response if other HTTP status code returned.
        /// </summary>
        public virtual Task<TResponse> PutAsync<TRequest, TResponse>(string route, TRequest request)
        {
            return RequestAsync<TResponse>(GetHttpClient().PutAsJsonAsync(route, request));
        }

        /// <summary>
        /// Calls the WebApi service with whatever HttpClient call you provide.
        /// </summary>
        public virtual Task<TResponse> CallAsync<TResponse>(Func<HttpClient, Task<TResponse>> httpClientCall)
        {
            
            return httpClientCall(GetHttpClient());
        }




        private async Task<TResponse> RequestAsync<TResponse>(Task<HttpResponseMessage> httpFunc)
        {
            var response = await httpFunc.ConfigureAwait(false);
            if (response.IsSuccessStatusCode) // || response.StatusCode.IsValidationFailedStatus())
            {

                //return await response.Content.ReadAsAsync<TResponse>()
                //    .ConfigureAwait(false);

                return await response.Deserialize<TResponse>().ConfigureAwait(false);
            }

            return await response.HandleInvalidResponse<TResponse>().ConfigureAwait(false);
        }




    }
}