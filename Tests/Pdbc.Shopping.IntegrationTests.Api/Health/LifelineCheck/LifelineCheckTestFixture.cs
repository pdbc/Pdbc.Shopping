using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Health.LifelineCheck;

namespace Pdbc.Shopping.IntegrationTests.Api.Health.LifelineCheck
{
    public class LifelineCheckTestFixture : ShoppingIntegrationApiRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetService<IHealthWebApiService>();
            return new LifelineCheckTest(service, base.Context);
        }
    }
}