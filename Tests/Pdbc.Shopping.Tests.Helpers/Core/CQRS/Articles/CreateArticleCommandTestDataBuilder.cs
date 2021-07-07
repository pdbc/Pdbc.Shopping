using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.Core.CQRS.Articles.Create;
using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Tests.Helpers.Core.CQRS.Articles
{
    public class CreateArticleCommandTestDataBuilder : CreateArticleCommandBuilder
    {
        public CreateArticleCommandTestDataBuilder()
        {
            Article = new ArticleCreateDtoBuilder().Build();
        }
    }
}
