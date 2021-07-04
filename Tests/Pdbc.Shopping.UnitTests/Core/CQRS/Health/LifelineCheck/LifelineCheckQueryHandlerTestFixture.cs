using System.Threading;
using NUnit.Framework;
using Pdbc.Music.Core.CQRS.ErrorMessages.Get;
using Pdbc.Shopping.Core.CQRS.Health.LifelineCheck;
using Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Health;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Resources.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Health.LifelineCheck
{
    [TestFixture]
    public class LifelineCheckQueryHandlerTestFixture : ContextSpecification<LifelineCheckCommandHandler>
    {
        private CancellationToken _cancelationToken;
        protected LifelineCheckCommand Command { get; set; }

        protected LifelineCheckResult Result { get; set; }
        protected override void Establish_context()
        {
            base.Establish_context();
            _cancelationToken = new CancellationToken();

            Command = new LifelineCheckQueryTestDataBuilder().Build();
        }

        protected override void Because()
        {
            Result = SUT.Handle(Command, _cancelationToken)
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
