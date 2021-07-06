using System;

namespace Pdbc.Shopping.DTO.Articles
{
    public interface IArticleInfoDto
    {
        String Name { get; set; }
    }

    public class ArticleInfoDto : IArticleInfoDto
    {
        public string Name { get; set; }
    }
}