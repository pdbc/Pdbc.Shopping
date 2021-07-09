using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Articles.Create;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.IntegrationTests.Cqrs.Articles.Create
{
    public class CreateArticleWithArticleAsNullTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<IArticlesCqrsService>();
            return new CreateArticleWithArticleAsNullTest(service, base.Context);
        }
    }
}