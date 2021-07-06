namespace Pdbc.Shopping.DTO.Articles
{
    public interface IArticleDetailDto : IArticleInfoDto
    {

    }

    public class ArticleDetailDto : IArticleDetailDto
    {
        public string Name { get; set; }
    }

}