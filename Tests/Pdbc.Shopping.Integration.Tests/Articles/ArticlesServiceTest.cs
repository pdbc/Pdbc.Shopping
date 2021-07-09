using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests.Articles
{
    public abstract class ArticlesServiceTest<TResult> : IntegrationTest<TResult> where TResult : ShoppingResponse
    {
        protected IArticlesService Service;

        protected ArticlesServiceTest(IArticlesService service, ShoppingDbContext dbContext) : base(dbContext)
        {
            Service = service;
        }
    }
}
