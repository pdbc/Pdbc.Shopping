using System.Threading;
using Moq;
using NUnit.Framework;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.Get;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Resources.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Resources.ErrorMessages.Get
{
    [TestFixture]
    public class GetErrorMessageQueryHandlerTestFixture : ContextSpecification<GetErrorMessageQueryHandler>
    {
        private CancellationToken _cancelationToken;
        protected GetErrorMessageQuery Query { get; set; }

        protected GetErrorMessageViewModel Result { get; set; }
        protected override void Establish_context()
        {
            base.Establish_context();
            _cancelationToken = new CancellationToken();

            Query = new GetErrorMessageQueryTestDataBuilder().Build();


        }

        protected override void Because()
        {
            Result = SUT.Handle(Query, _cancelationToken)
                .GetAwaiter()
                .GetResult();
        }

        [Test]
        public void Verify_view_model_returned()
        {
            Result.ShouldNotBeNull();
        }
    }
}
