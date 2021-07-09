using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private ValidationBag _validationBag;

        private CreateArticleCommand _command;

        protected override void Establish_context()
        {
            base.Establish_context();

            _validationBag = new ValidationBag();

            _command = new CreateArticleCommandTestDataBuilder();
        }

        protected override void Because()
        {
            SUT.Validate(_command, _validationBag).GetAwaiter().GetResult();
        }

        [Test, Ignore("Expection not working, How to set SetValidator expectation")]
        public void Verify()
        {
            ArticleCreateDtoValidator.AssertWasCalled(x => x.Validate(_command.Article), Times.Once());
        }

        [Test, Ignore("Expection not working, How to set SetValidator expectation")]
        public void Verify_Async()
        {
            ArticleCreateDtoValidator.AssertWasCalled(x => x.ValidateAsync(_command.Article, It.IsAny<CancellationToken>()), Times.Once());
        }
    }

}
