using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Crash;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.IntegrationTests.Cqrs.Crash
{
    public class CrashPostShoppingExceptionTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<ICrashCqrsService>();
            return new CrashPostShoppingExceptionTest(service, base.Context);
        }
    }
}