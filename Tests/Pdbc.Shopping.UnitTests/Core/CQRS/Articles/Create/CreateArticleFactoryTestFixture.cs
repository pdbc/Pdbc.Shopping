using NUnit.Framework;

using Pdbc.Shopping.Core.CQRS.Articles.Create;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Articles;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Articles.Create
{
    [TestFixture]
    public class CreateArticleFactoryTestFixture : ContextSpecification<CreateArticleCommandFactory>
    {
        protected CreateArticleCommand Command { get; set; }

        protected Article Result { get; set; }

        protected override void Establish_context()
        {
            base.Establish_context();
            Command = new CreateArticleCommandTestDataBuilder()
                .Build();
        }

        protected override void Because()
        {
            Result = SUT.Create(Command.Article);
        }

        [Test]
        public void Verify_domain_object_correctly_filled()
        {
            Result.Name.ShouldBeEqualTo(Command.Article.Name);
        }

        [Test]
        public void Verify_domain_object_not_null()
        {
            Result.ShouldNotBeNull();
        }
    }
}
