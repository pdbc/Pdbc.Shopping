using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Tests.Helpers.DTO.Articles
{
    public class ArticleCreateDtoTestDataBuilder : ArticleCreateDtoBuilder
    {
        public ArticleCreateDtoTestDataBuilder()
        {
            Name = UnitTestValueGenerator.GenerateRandomCode(32);
        }
    }
}
