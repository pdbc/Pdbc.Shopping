using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.ServiceAgent;

namespace Pdbc.Music.Api.ServiceAgent
{
    /// <summary>
    /// Base class for implementing WEB API Rest methods.  This service abstracts the <see cref="IWebApiClientProxy"/> from the SD Framework
    /// to include all features developed in there (OIDC security, ...)
    /// </summary>
    public abstract class WebApiService
    {
        /// <summary>
        /// Logger used for logging into WebApiService class en base classes.
        /// </summary>
        protected ILog Log = LogManager.GetLogger<WebApiService>();

        private readonly string _routePrefix;

        /// <summary>
        /// The web API client proxy to be used.
        /// </summary>
        private IWebApiClientProxy _webApiClient;

        /// <summary>
        /// The web API client proxy to be used.
        /// </summary>
        protected Func<IWebApiClientProxy> WebApiClientFactory;

        /// <summary>
        /// Creates a new web api client
        /// </summary>
        /// <returns></returns>
        protected IWebApiClientProxy GetWebApiClient()
        {
            if (_webApiClient != null)
            {
                // TODO Verify status of proxy => retry creation otherwise?
                return _webApiClient;
            }

            if (WebApiClientFactory == null)
                throw new ApplicationException("WebApiClient cannot be created");

            _webApiClient = WebApiClientFactory();

            return _webApiClient;
        }

        /// <summary>
        /// Constructor to create a
        /// </summary>
        /// <param name="webApiClientFactory"></param>
        /// <param name="routePrefix"></param>
        protected WebApiService(Func<IWebApiClientProxy> webApiClientFactory, string routePrefix)
        {
            WebApiClientFactory = webApiClientFactory;
            _routePrefix = routePrefix;
        }



        /// <summary>
        /// Helper method to deserialize the WEB API response to a type specific Response object.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        protected TResponse Deserialize<TResponse>(HttpResponseMessage result)
        {
            Log.Info($"Headers : {result.Headers}");
            Log.Info($"IsSuccess : {result.IsSuccessStatusCode}");
            Log.Info($"StatusCode : {result.StatusCode}");

            // If we have an HTTP200 veriant :
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var response = result.Content
                        .ReadAsAsync<TResponse>(new List<MediaTypeFormatter>
                        {
                            new JsonMediaTypeFormatter(),
                            new BinaryMediaTypeFormatter()
                        })
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();

                    return response;
                }
                catch (UnsupportedMediaTypeException)
                {
                    var responseString = result.Content.ReadAsStringAsync().Result;

                    var validationMessages = new List<ValidationMessage>();
                    validationMessages.Add(new ValidationMessage()
                    {
                        Code = "InternalServerError", //nameof(Notifications.InternalServerError),
                        Message = responseString
                    });

                    var validationResult = new ValidationResult
                    {
                        Messages = validationMessages
                    };

                    var functionalityDomainResponse = new FunctionalityDomainResponse { Notifications = validationResult };


                    var r = JsonConvert.SerializeObject(functionalityDomainResponse);

                    throw new FunctionalityDomainWebApiException("InternalServerError", r);


                }
            }
            else if (result.StatusCode == HttpStatusCode.Forbidden)
            {
                var ex = new WebApiClientException($"Invalid HTTP Status code response - {result.StatusCode} - {result.ReasonPhrase} - {result.RequestMessage} [{result.Headers.WwwAuthenticate}]");
                ex.HttpStatusCode = result.StatusCode;
                throw ex;
            }
            else if (result.StatusCode == HttpStatusCode.InternalServerError)
            {
                var ex = new WebApiClientException($"Internal Server Error - {result.StatusCode} - {result.ReasonPhrase} - {result.RequestMessage} [{result.Headers.WwwAuthenticate}]");
                ex.HttpStatusCode = result.StatusCode;
                throw ex;
            }
            else
            {
                string response = TryToGetJsonResponse(result);
                if (response == null)
                {
                    var ex = new WebApiClientException($"Invalid HTTP Status code response - {result.StatusCode} - {result.ReasonPhrase} - {result.RequestMessage} [{result.Headers.WwwAuthenticate}]");
                    ex.HttpStatusCode = result.StatusCode;
                    throw ex;

                }
                else
                {
                    var ex = new FunctionalityDomainWebApiException($"Invalid HTTP Status code response - {result.StatusCode} - {result.ReasonPhrase} - {result.RequestMessage} [{result.Headers.WwwAuthenticate}]", response);
                    ex.HttpStatusCode = result.StatusCode;
                    throw ex;
                    //throw new WebApiClientException($"Internal Server Error - {response.Notifications.To
                }
            }

        }

        private string TryToGetJsonResponse(HttpResponseMessage result)
        {
            try
            {
                var response = result.Content
                    .ReadAsAsync<FunctionalityDomainResponse>(new List<MediaTypeFormatter>
                        {new JsonMediaTypeFormatter(), new BinaryMediaTypeFormatter()})
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                return JsonConvert.SerializeObject(response);
            }
            catch
            {
                return null;
            }

        }


        #region GET
        /// <summary>
        /// REST API Get method to a specific route
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="subroute">The subroute.</param>
        /// <returns></returns>
        protected TResponse Get<TResponse>(string subroute = null)
        {
            var route = $"{_routePrefix}";
            if (subroute != null)
            {
                route = $"{_routePrefix}/{subroute}";
            }

            Log.Info($"Get {route}");

            var result = GetWebApiClient().CallAsync(s => s.GetAsync(route))
                .GetAwaiter()
                .GetResult();

            return Deserialize<TResponse>(result);
        }

        /// <summary>
        /// REST API Get method to a specific route
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="subroute">The subroute.</param>
        /// <returns></returns>
        protected async Task<TResponse> GetAsync<TResponse>(string subroute = null)
        {
            var route = $"{_routePrefix}";
            if (subroute != null)
            {
                route = $"{_routePrefix}/{subroute}";
            }

            Log.Info($"Get {route}");

            var result = await GetWebApiClient().CallAsync(s => s.GetAsync(route));

            return Deserialize<TResponse>(result);
        }
        #endregion


        //#region Get / GetById, Get or List
        ///// <summary>
        ///// REST API Get method
        ///// </summary>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        //protected TResponse GetById<TResponse>(long id)
        //{
        //    var route = $"{_routePrefix}/{id}";
        //    Log.Info($"GetById {route}");

        //    var result = GetWebApiClient().CallAsync(s => s.GetAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);

        //}



        ///// <summary>
        ///// REST API Get method to a specific route
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="subroute">The subroute.</param>
        ///// <returns></returns>
        //protected TResponse Get<TRequest, TResponse>(TRequest request, string subroute = null)
        //{
        //    var route = $"{_routePrefix}";
        //    if (request is IProvideIdentifierForUrl provideIdentifierForUrlRequest)
        //    {
        //        route = $"{route}/{provideIdentifierForUrlRequest.GetIdentifier()}";
        //    }
        //    if (subroute != null)
        //    {
        //        route = $"{route}/{subroute}";
        //    }
        //    if (request is ITransformToUriQueryStringParameters transformToUriQueryStringParameters)
        //    {
        //        route = $"{route}?{transformToUriQueryStringParameters.ToUriQueryStringParameters()}";
        //    }

        //    Log.Info($"Get {route}");

        //    var result = GetWebApiClient().CallAsync(s => s.GetAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);
        //}

        ///// <summary>
        ///// REST API Get method
        ///// </summary>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <returns></returns>
        //protected TResponse GetByIdentifier<TRequest, TResponse>(string identifierType, TRequest request, string subroute = null, bool ignoreIdentifiersInUrl = false) where TRequest : IProvideIdentifierForUrl
        //{
        //    var route = $"{_routePrefix}"; 
        //    if(!string.IsNullOrWhiteSpace(identifierType)) 
        //        route = $"{route}/{identifierType}";
        //    if (!ignoreIdentifiersInUrl)
        //    {
        //        route = $"{route}/{request.GetIdentifier()}";
        //    }
        //    if (subroute != null)
        //    {
        //        route = $"{route}/{subroute}";
        //    }
        //    if (request is ITransformToUriQueryStringParameters transformRequest)
        //    {
        //        route = $"{route}?{transformRequest.ToUriQueryStringParameters()}";
        //    }

        //    Log.Info($"GetByIdentifier - Id {route}");

        //    var result = GetWebApiClient().CallAsync(s => s.GetAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);

        //}

        ///// <summary>
        ///// REST API GET method to retrieve lists
        ///// </summary>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <returns></returns>
        //protected TResponse List<TRequest, TResponse>(TRequest request) where TRequest : ITransformToUriQueryStringParameters
        //{
        //    return List<TRequest,TResponse>(request, null);
        //}


        //protected TResponse ListSpecial<TRequest, TResponse>(TRequest request, string subroute) 
        //{
        //    if (request == null) throw new ArgumentNullException(nameof(request));

        //    var route = $"{_routePrefix}";

        //    if (request is IProvideIdentifierForUrl provideIdentifierForUrlRequest)
        //    {
        //        route = $"{route}/{provideIdentifierForUrlRequest.GetIdentifier()}";
        //    }
        //    if (!string.IsNullOrWhiteSpace(subroute))
        //    {
        //        route = $"{route}/{subroute}";
        //    }

        //    Log.Info($"List {route}");

        //    var result = GetWebApiClient().CallAsync(s => s.GetAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);
        //}

        //protected TResponse List<TRequest, TResponse>(TRequest request, string subroute) where TRequest : ITransformToUriQueryStringParameters
        //{
        //    if (request == null) throw new ArgumentNullException(nameof(request));

        //    var route = $"{_routePrefix}";

        //    if (request is IProvideIdentifierForUrl provideIdentifierForUrlRequest)
        //    {
        //        route = $"{route}/{provideIdentifierForUrlRequest.GetIdentifier()}";
        //    }
        //    if (!string.IsNullOrWhiteSpace(subroute))
        //    {
        //        route = $"{route}/{subroute}";
        //    }

        //    route = $"{route}?{request.ToUriQueryStringParameters()}";

        //    Log.Info($"List {route}");

        //    var result = GetWebApiClient().CallAsync(s => s.GetAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);
        //}

        //#endregion

        //#region POST / Create
        ///// <summary>
        ///// REST API POST method to create an object, with optional a specific route
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Post<TRequest, TResponse>(TRequest request, string subRoute = "")
        //{
        //    return Create<TRequest, TResponse>(request, subRoute);
        //}

        ///// <summary>
        ///// REST API POST method to create an object, with optional a specific route
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Upload<TRequest, TResponse>(TRequest request, string subRoute = "") where TRequest : IFileContentMessage where TResponse : new()
        //{
        //    var route = $"{_routePrefix}";
        //    if (subRoute != "")
        //    {
        //        route = $"{_routePrefix}/{subRoute}";
        //    }
        //    Log.Info($"Create {route}");

        //    var result = GetWebApiClient().UploadAsync<TResponse>(route, request.FileContent)
        //        .GetAwaiter()
        //        .GetResult();

        //    return result;
        //}

        ///// <summary>
        ///// REST API POST method to create an object, with optional a specific route
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Create<TRequest, TResponse>(TRequest request, string subRoute = "")
        //{
        //    var route = $"{_routePrefix}";
        //    if (!string.IsNullOrWhiteSpace(subRoute))
        //    {
        //        route = $"{_routePrefix}/{subRoute}";
        //    }
        //    Log.Info($"Create {route}");


        //    var result = GetWebApiClient().PostAsync<TRequest, TResponse>(route, request)
        //        .GetAwaiter()
        //        .GetResult();

        //    return result;
        //}

        // /// <summary>
        ///// REST API POST method to create an object for an identifier, with optional an identifier type and specific route
        ///// example of the route query parameters order: profile/{identifiertype}/{identifier}/{subroute}
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="identifierType">the type of the identifier</param>
        ///// <param name="subroute">the sub route</param>
        ///// <returns></returns>
        //protected TResponse CreateWithIdentifier<TRequest, TResponse>(TRequest request, string identifierType = null, string subroute = null) where TRequest : IProvideIdentifierForUrl
        //{
        //    var route = $"{_routePrefix}";

        //    if (!string.IsNullOrEmpty(identifierType))
        //    {
        //        route = $"{route}/{identifierType}";
        //    }

        //    route = $"{route}/{request.GetIdentifier()}";

        //    if (subroute != null)
        //    {
        //        route = $"{route}/{subroute}";
        //    }

        //    Log.Info($"Create - Id {route}");

        //    var result = GetWebApiClient().PostAsync<TRequest, TResponse>(route, request)
        //        .GetAwaiter()
        //        .GetResult();

        //    return result;
        //}

        //#endregion

        //#region PUT / Update

        ///// <summary>
        ///// REST API PUT method to update an object, with optional a specific route.
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="subRoutePrefix">The sub route prefix</param>
        ///// <param name="id">The identifier.</param>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route suffix.</param>
        ///// <returns></returns>
        //protected TResponse Put<TRequest, TResponse>(string subRoutePrefix, long id, TRequest request, string subRoute = "")
        //{
        //    var route = $"{_routePrefix}/{subRoutePrefix}/{id}/{subRoute}";
        //    Log.Info($"Update {route}");


        //    var result = GetWebApiClient().PutAsync<TRequest, TResponse>(route, request)
        //        .GetAwaiter()
        //        .GetResult();

        //    return result;
        //} 

        ///// <summary>
        ///// REST API PUT method to update an object, with optional a specific route.
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="id">The identifier.</param>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Put<TRequest, TResponse>(long id, TRequest request, string subRoute = "")
        //{
        //    var route = $"{_routePrefix}/{id}/{subRoute}";
        //    Log.Info($"Update {route}");


        //    var result = GetWebApiClient().PutAsync<TRequest, TResponse>(route, request)
        //        .GetAwaiter()
        //        .GetResult();

        //    return result;
        //}

        ///// <summary>
        ///// REST API PUT method to update an object, with optional a specific route.
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="id">The identifier.</param>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Update<TRequest, TResponse>(long id, TRequest request, string subRoute = "")
        //{
        //    return Put<TRequest, TResponse>(id, request, subRoute);
        //}


        ///// <summary>
        ///// REST API PUT method to update an object, with optional a specific route.
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Put<TRequest, TResponse>(TRequest request, string subRoute = "")
        //{
        //    var route = $"{_routePrefix}";
        //    if (!string.IsNullOrWhiteSpace(subRoute))
        //    {
        //        route = $"{_routePrefix}/{subRoute}";
        //    }
        //    Log.Info($"Update {route}");


        //    var result = GetWebApiClient().PutAsync<TRequest, TResponse>(route, request)
        //        .GetAwaiter()
        //        .GetResult();

        //    return result;
        //}

        ///// <summary>
        ///// REST API PUT method to update an object, with optional a specific route.
        ///// </summary>
        ///// <typeparam name="TRequest">The type of the request.</typeparam>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="request">The request.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Update<TRequest, TResponse>(TRequest request, string subRoute = "")
        //{
        //    return Put<TRequest, TResponse>(request, subRoute);
        //}
        //#endregion

        //#region Delete
        ///// <summary>
        ///// REST API DELETE method to delete an object, with optional a specific route.
        ///// </summary>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <param name="id">The identifier.</param>
        ///// <param name="subRoute">The sub route.</param>
        ///// <returns></returns>
        //protected TResponse Delete<TResponse>(long id, string subRoute = "")
        //{
        //    var route = string.IsNullOrWhiteSpace(subRoute) ? $"{_routePrefix}/{id}" : $"{_routePrefix}/{subRoute}/{id}";
        //    Log.Info($"Delete {route}");


        //    HttpResponseMessage result = GetWebApiClient().CallAsync(s => s.DeleteAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);
        //}

        ///// <summary>
        ///// REST API DELETE method to delete an object
        ///// </summary>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <returns></returns>
        //protected TResponse Delete<TResponse>()
        //{
        //    var route = $"{_routePrefix}";
        //    Log.Info($"Delete {route}");

        //    HttpResponseMessage result = GetWebApiClient().CallAsync(s => s.DeleteAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);
        //}


        ///// <summary>
        ///// REST API Get method
        ///// </summary>
        ///// <typeparam name="TResponse">The type of the response.</typeparam>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <returns></returns>
        //protected TResponse Delete<TRequest, TResponse>(string identifierType, TRequest request, string subroute = null, bool ignoreIdentifiersInUrl = false) where TRequest : IProvideIdentifierForUrl
        //{
        //    var route = $"{_routePrefix}/{identifierType}";
        //    if (!ignoreIdentifiersInUrl)
        //    {
        //        route = $"{route}/{request.GetIdentifier()}";
        //    }
        //    if (subroute != null)
        //    {
        //        route = $"{route}/{subroute}";
        //    }
        //    if (request is ITransformToUriQueryStringParameters transformRequest)
        //    {
        //        route = $"{route}?{transformRequest.ToUriQueryStringParameters()}";
        //    }

        //    Log.Info($"Delete - route {route}");

        //    var result = GetWebApiClient().CallAsync(s => s.DeleteAsync(route))
        //        .GetAwaiter()
        //        .GetResult();

        //    return Deserialize<TResponse>(result);

        //}
        //#endregion


    }
}
