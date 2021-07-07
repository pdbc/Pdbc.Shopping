namespace Pdbc.Shopping.DTO.Articles
{

    public interface IArticleCreateDto : IArticleInfoDto
    {

    }
    public class ArticleCreateDto : IArticleCreateDto
    {
        public string Name { get; set; }
    }
}