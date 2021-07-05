using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Errors.List;

namespace Pdbc.Shopping.IntegrationTests.Api.Errors.List
{
    public class ListErrorMessagesQueryHandlerTestFixture : ShoppingIntegrationApiRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IErrorMessagesWebApiService>();
            return new ListErrorMessagesTest(service, base.Context);
        }
    }
}