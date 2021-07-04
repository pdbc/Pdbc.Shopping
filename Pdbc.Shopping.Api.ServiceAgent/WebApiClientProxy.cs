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
        private readonly Uri _baseAddress;
        private readonly string _name;
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Gets or sets the timeout to wait before the request times out.
        /// </summary>
        public TimeSpan ClientTimeout { get; private set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public WebApiClientProxy(IHttpClientFactory factory, String name, int timeoutInMinutes = 5)
        {
            _httpClientFactory = factory;
            _name = name;
            ClientTimeout = TimeSpan.FromMinutes(timeoutInMinutes);
        }

        /// <summary>
        /// The default message handler to use for the HttpClient
        /// </summary>
        //protected virtual HttpClientHandler GetHttpClientHandler()
        //{
        //    return new HttpClientHandler { UseDefaultCredentials = true };
        //}

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
            //return _client ?? (_client = new HttpClient(GetHttpClientHandler()) { Timeout = ClientTimeout, BaseAddress = _baseAddress });
        }

        /// <summary>
        /// Posts to the WebApi service method the JSON-formatted TRequest.
        /// If response indicates a Success or Validation status, returns the response read as TResponse.
        /// Throws an Exception with the stringified response if other HTTP status code returned.
        /// </summary>
        public virtual Task<TResponse> PostAsync<TRequest, TResponse>(string method, TRequest request)
        {
            return RequestAsync<TResponse>(GetHttpClient().PostAsJsonAsync(method, request));
        }

        /// <summary>
        /// Puts to the WebApi service method the JSON-formatted TRequest.
        /// If response indicates a Succes or Validation status, returns the response read as TResponse.
        /// Throws an Exception with the stringified response if other HTTP status code returned.
        /// </summary>
        public virtual Task<TResponse> PutAsync<TRequest, TResponse>(string method, TRequest request)
        {
            return RequestAsync<TResponse>(GetHttpClient().PutAsJsonAsync(method, request));
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