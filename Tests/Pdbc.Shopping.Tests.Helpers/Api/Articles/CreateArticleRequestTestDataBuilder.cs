using Pdbc.Shopping.Api.Contracts.Requests.Articles;
using Pdbc.Shopping.DTO.Articles;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers.DTO.Articles;

namespace Pdbc.Shopping.Tests.Helpers.Api.Articles
{
    public class CreateArticleRequestTestDataBuilder : CreateArticleRequestBuilder
    {
        public CreateArticleRequestTestDataBuilder()
        {
            base.Article = new ArticleCreateDtoTestDataBuilder();
        }
    }
}
