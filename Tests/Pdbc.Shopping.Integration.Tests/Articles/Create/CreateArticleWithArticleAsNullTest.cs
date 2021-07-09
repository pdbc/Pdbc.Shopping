using Pdbc.Shopping.Api.Contracts.Requests.Articles;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Tests.Helpers.Api.Articles;
using Pdbc.Shopping.Tests.Helpers.Api.Validation;

namespace Pdbc.Shopping.Integration.Tests.Articles.Create
{
    public class CreateArticleWithArticleAsNullTest : ArticlesServiceTest<CreateArticleResponse>
    {
        public CreateArticleWithArticleAsNullTest(IArticlesService service, ShoppingDbContext dbContext)
            : base(service, dbContext)
        {
        }

        private CreateArticleRequest _request;

        public override void Setup()
        {
            _request = new CreateArticleRequestTestDataBuilder()
                .WithArticle(null);
        }

        public override void Cleanup()
        {
        }

        public override CreateArticleResponse PerformAction()
        {
            return Service.Create(_request)
                .GetAwaiter()
                .GetResult();
        }

        public override void VerifyResponse(CreateArticleResponse response)
        {
            response.Notifications.ExpectAnError();
        }
    }
}