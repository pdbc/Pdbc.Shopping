namespace Pdbc.Shopping.DTO.Articles
{

    public interface IArticleUpdateDto : IArticleInfoDto, IIdentifierDto
    {

    }
    public class ArticleUpdateDto : IArticleUpdateDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}