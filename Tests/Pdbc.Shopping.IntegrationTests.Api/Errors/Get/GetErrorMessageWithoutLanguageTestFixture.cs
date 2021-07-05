using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Errors.Get;

namespace Pdbc.Shopping.IntegrationTests.Api.Errors.Get
{
    public class GetErrorMessageWithoutLanguageTestFixture : ShoppingIntegrationApiRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IErrorMessagesWebApiService>();
            return new GetErrorMessageWithoutLanguageTest(service, base.Context);
        }
    }
}