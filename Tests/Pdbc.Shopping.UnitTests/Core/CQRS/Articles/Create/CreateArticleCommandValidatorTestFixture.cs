using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS.Articles.Create;
using Pdbc.Shopping.Core.Validators.Articles;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Articles;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandValidatorTestFixture : ContextSpecification<CreateArticleCommandValidator>
    {
        private IArticleCreateDtoValidator ArticleCreateDtoValidator => Dependency<IArticleCreateDtoValidator>();

        protected ValidationBag validationBag;

        private CreateArticleCommand _command;

        protected override void Establish_context()
        {
            base.Establish_context();

            validationBag = new ValidationBag();

            _command = new CreateArticleCommandTestDataBuilder();
        }

        protected override void Because()
        {
            SUT.Validate(_command, validationBag).GetAwaiter().GetResult();
        }

        [Test, Ignore("Expection set not correct")]
        public void Verify()
        {
            ArticleCreateDtoValidator.AssertWasCalled(x => x.Validate(_command.Article), Times.Once());
        }
    }

}
