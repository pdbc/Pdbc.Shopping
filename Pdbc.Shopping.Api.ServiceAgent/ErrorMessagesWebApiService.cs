using System;
using System.Net.Http;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors;
using Pdbc.Shopping.Api.ServiceAgent.Extensions;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Api.ServiceAgent
{

    public class ErrorMessagesWebApiService : IErrorMessagesWebApiService
    {
        private string _route = "Resources/errors";
        private readonly WebApiClientProxy _proxy;

        public ErrorMessagesWebApiService(IHttpClientFactory clientFactory, IShoppingApiServiceAgentConfiguration configuration)
        {
            _proxy = new WebApiClientProxy(clientFactory, configuration.Name);
        }

        public async Task<ListErrorMessagesResponse> ListErrorMessages(ListErrorMessagesRequest request)
        {
            if (String.IsNullOrEmpty(request.Language))
            {
                return new ListErrorMessagesResponse()
                {
                    Notifications = new ValidationResult(nameof(ErrorResources.LanguageIsEmpty))
                };
            }

            var response = await _proxy.CallAsync(c => c.GetAsync($"{_route}/{request.Language}"));
            return await response.Deserialize<ListErrorMessagesResponse>();
        }

        public async Task<GetErrorMessageResponse> GetErrorMessage(GetErrorMessageRequest request)
        {
            if (String.IsNullOrEmpty(request.Language))
            {
                return new GetErrorMessageResponse()
                {
                    Notifications = new ValidationResult(nameof(ErrorResources.LanguageIsEmpty))
                };
            }

            if (String.IsNullOrEmpty(request.Key))
            {
                return new GetErrorMessageResponse()
                {
                    Notifications = new ValidationResult(nameof(ErrorResources.ResourceKeyIsEmpty))
                };
            }

            var response = await _proxy.CallAsync(c => c.GetAsync($"{_route}/{request.Language}/{request.Key}"));
            return await response.Deserialize<GetErrorMessageResponse>();


        }
    }
}
