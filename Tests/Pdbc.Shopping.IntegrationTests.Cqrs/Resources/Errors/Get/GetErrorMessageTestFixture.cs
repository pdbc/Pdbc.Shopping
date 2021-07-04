using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Errors.Get;
using Pdbc.Shopping.Integration.Tests.Health.LifelineCheck;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.IntegrationTests.Cqrs.Resources.Errors.Get
{
    public class GetErrorMessageTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IErrorMessagesCqrsService>();
            return new GetErrorMessageTest(service, base.Context);
        }
    }
}