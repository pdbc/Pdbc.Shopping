using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Crash;

namespace Pdbc.Shopping.IntegrationTests.Api.Crash
{
    public class CrashGetShoppingExceptionTestFixture : ShoppingIntegrationApiRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<ICrashWebApiService>();
            return new CrashGetShoppingExceptionTest(service, base.Context);
        }
    }
}