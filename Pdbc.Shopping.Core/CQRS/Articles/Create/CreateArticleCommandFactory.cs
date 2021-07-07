using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandFactory : IFactory<IArticleCreateDto, Article>
    {
        public Article Create(IArticleCreateDto model)
        {
            var builder = new ArticleBuilder()
                    .WithName(model.Name)
                ;

            return builder.Build();
        }
    }
}
