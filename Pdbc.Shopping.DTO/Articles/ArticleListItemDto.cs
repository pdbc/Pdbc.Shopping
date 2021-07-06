namespace Pdbc.Shopping.DTO.Articles
{
    public interface IArticleListItemDto : IArticleInfoDto, IIdentifierDto
    {

    }
    public class ArticleListItemDto : IArticleListItemDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }


}