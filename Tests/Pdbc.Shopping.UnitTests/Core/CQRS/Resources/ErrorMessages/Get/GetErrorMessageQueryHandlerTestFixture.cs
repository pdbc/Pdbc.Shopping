using Moq;
using NUnit.Framework;
using Pdbc.Music.Core.CQRS.ErrorMessages.Get;
using Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get;
using Pdbc.Shopping.Tests.Helpers;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Resources.ErrorMessages.Get
{
    [TestFixture]
    public class GetErrorMessageQueryHandlerTestFixture : ContextSpecification<GetErrorMessageQueryHandler>
    {
        protected GetErrorMessageQuery Query { get; set; }

        protected GetErrorMessageViewModel Result { get; set; }
        protected override void Establish_context()
        {
            base.Establish_context();
            Query = new GetErrorMessageQueryTestDataBuilder().Build();


        }

        protected override void Because()
        {
            Result = SUT.Query(Query)
                .GetAwaiter()
                .GetResult();
        }

        //[Test]
        //public void Verify_view_model_returned()
        //{
        //    Result.ShouldNotBeNull();
        //    Mediator.AssertWasCalled(x => x.Query(It.Is<GetTranslationsQuery>(y => y.Language == Query.Language && y.TranslationType == Query.TranslationType),
        //        It.IsAny<GetTranslationsViewModel>()));
        //}
    }
}
