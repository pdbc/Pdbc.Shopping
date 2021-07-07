using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleResult
    {
        public IArticleDetailDto Article { get; set; }
    }
}
