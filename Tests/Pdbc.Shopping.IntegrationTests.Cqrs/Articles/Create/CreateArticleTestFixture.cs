using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Articles.Create;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.IntegrationTests.Cqrs.Articles.Create
{
    public class CreateArticleTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IArticlesCqrsService>();
            return new CreateArticleTest(service, base.Context);
        }
    }
}