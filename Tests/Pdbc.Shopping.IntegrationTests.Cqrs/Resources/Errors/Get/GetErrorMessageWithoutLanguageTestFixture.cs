using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Errors.Get;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.IntegrationTests.Cqrs.Resources.Errors.Get
{
    public class GetErrorMessageWithoutLanguageTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IErrorMessagesCqrsService>();
            return new GetErrorMessageWithoutLanguageTest(service, base.Context);
        }
    }
}