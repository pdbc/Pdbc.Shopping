using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pdbc.Shopping.Core.Validators.Articles;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.DTO.Articles;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.Validators
{
    public class ArticleCreateDtoValidatorTestFixture : ContextSpecification<ArticleCreateDtoValidator>
    {

        [Test]
        public void Verify_no_error_code_given_when_object_fully_constructed()
        {
            var item = new ArticleCreateDtoTestDataBuilder().Build();
            SUT.ExpectNoValidationError(item);
        }

        [Test]
        public void Verify_error_code_given_when_name_is_empty()
        {
            var item = new ArticleCreateDtoTestDataBuilder()
                .Build();

            SUT.ExpectValidationErrorForString(item, (p, v) => p.Name = v,
                nameof(ErrorResources.ArticleNameIsRequired));
        }
        
    }
}
