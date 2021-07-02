using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.List;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.List;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Resources.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Resources.ErrorMessages.List
{
    [TestFixture]
    public class ListErrorMessagesQueryHandlerTestFixture : ContextSpecification<ListErrorMessagesQueryHandler>
    {
        private CancellationToken _cancelationToken;
        protected ListErrorMessagesQuery Query { get; set; }

        protected ListErrorMessagesViewModel Result { get; set; }

        protected override void Establish_context()
        {
            base.Establish_context();
            _cancelationToken = new CancellationToken();

            Query = new ListErrorMessagesQueryTestDataBuilder().Build();
        }

        protected override void Because()
        {
            Result = SUT.Handle(Query, _cancelationToken).GetAwaiter().GetResult();
        }

        [Test]
        public void Verify_view_model_returned()
        {
            Result.ShouldNotBeNull();
        }
    }
}
