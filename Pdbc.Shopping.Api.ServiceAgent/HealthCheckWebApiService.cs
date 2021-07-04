using System.Net.Http;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests.Health;
using Pdbc.Shopping.Api.ServiceAgent.Extensions;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;

namespace Pdbc.Shopping.Api.ServiceAgent
{
    public class HealthCheckWebApiService : IHealthCheckWebApiService
    {
        private string _route = "HealthCheck";
        private readonly WebApiClientProxy _proxy;

        public HealthCheckWebApiService(IHttpClientFactory clientFactory, IShoppingApiServiceAgentConfiguration configuration)
        {
            _proxy = new WebApiClientProxy(clientFactory, configuration.Name);
        }

        public async Task<LifelineCheckResponse> LifelineCheck(LifelineCheckRequest request)
        {
            var response = await _proxy.CallAsync(c => c.GetAsync($"{_route}/LifelineCheck"));
            return await response.Deserialize<LifelineCheckResponse>();
        }
    }
}
