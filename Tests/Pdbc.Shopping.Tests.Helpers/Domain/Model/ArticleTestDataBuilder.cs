using System;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Tests.Helpers.Domain.Model
{
    public class ArticleTestDataBuilder : ArticleBuilder
    {
        public ArticleTestDataBuilder()
        {
            this.Name = UnitTestValueGenerator.GenerateText(128);

            // Auditable 
            this.CreatedBy = UnitTestValueGenerator.GenerateText(16);
            this.ModifiedBy = UnitTestValueGenerator.GenerateText(16);
            this.CreatedOn = DateTime.Now.AddDays(-5);
            this.ModifiedOn = DateTime.Now.AddDays(-2);
        }

        //public ArticleTestDataBuilder AsDiscontinuedArticle()
        //{
        //    this.IsDiscontinued = true;
        //}
    }
}
