using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Pdbc.Shopping.Core.CQRS;
using Pdbc.Shopping.Core.CQRS.Articles.Create;
using Pdbc.Shopping.Data.Repositories;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.DTO.Articles;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Articles;
using Pdbc.Shopping.Tests.Helpers.Domain.Model;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandHandlerTestFixture : ContextSpecification<CreateArticleCommandHandler>
    {
        protected CancellationToken _cancellationToken;

        protected CreateArticleCommand Command { get; set; }
        protected Article DomainObject { get; set; }

        protected IArticleRepository Repository => Dependency<IArticleRepository>();

        protected IFactory<IArticleCreateDto, Article> Factory => Dependency<IFactory<IArticleCreateDto, Article>>();

        protected override void Establish_context()
        {
            base.Establish_context();

            _cancellationToken = new CancellationToken();

            Command = new CreateArticleCommandTestDataBuilder().Build();
            DomainObject = new ArticleTestDataBuilder().Build();

            Factory.Stub(x => x.Create(Command.Article)).Return(DomainObject);
        }

        protected override void Because()
        {
            SUT.Handle(Command, _cancellationToken);
        }

        [Test]
        public void Verify_factory_called_to_create_domain_object()
        {
            Factory.AssertWasCalled(x => x.Create(Command.Article));
        }

        [Test]
        public void Verify_repository_called_to_save_domain_object()
        {
            Repository.AssertWasCalled(x => x.Insert(DomainObject));
        }
    }
}
