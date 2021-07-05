using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Pdbc.Shopping.Api.ServiceAgent.Interfaces;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Errors.Get;

namespace Pdbc.Shopping.IntegrationTests.Api.Errors.Get
{
    [TestFixture]
    public class GetErrorMessageTestFixture : ShoppingIntegrationApiRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IErrorMessagesWebApiService>();
            return new GetErrorMessageTest(service, base.Context);
        }


    }
}
