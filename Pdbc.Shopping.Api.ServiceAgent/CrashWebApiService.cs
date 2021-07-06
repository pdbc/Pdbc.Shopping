using System;
using System.Net.Http;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.ServiceAgent.Extensions;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;

namespace Pdbc.Shopping.Api.ServiceAgent
{
    public class CrashWebApiService : ICrashWebApiService
    {
        private string _route = "crash";
        private readonly WebApiClientProxy _proxy;

        public CrashWebApiService(IHttpClientFactory clientFactory, IShoppingApiServiceAgentConfiguration configuration)
        {
            _proxy = new WebApiClientProxy(clientFactory, configuration.Name);
        }
        

        public async Task CrashGet(int exceptionType)
        {
            var response = await _proxy.CallAsync(c => c.GetAsync($"{_route}/{exceptionType}"));
            await response.Deserialize<ShoppingResponse>();
        }

        public Task CrashPost(int exceptionType)
        {
            throw new NotImplementedException();
        }
    }
}