using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommand : ICommand<CreateArticleResult> 
    {
        public IArticleCreateDto Article { get; set; }
    }
}
