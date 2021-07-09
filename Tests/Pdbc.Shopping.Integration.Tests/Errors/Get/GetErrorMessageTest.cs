using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers.Api.Resources;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Integration.Tests.Errors.Get
{
    public class GetErrorMessageTest : ErrorMessageServiceTest<GetErrorMessageResponse>
    {
        public GetErrorMessageTest(IErrorMessagesService service, ShoppingDbContext dbContext) 
            : base(service, dbContext)
        {
        }

        private GetErrorMessageRequest _request;

        public override void Setup()
        {
            _request = new GetErrorMessageRequestTestDataBuilder();
        }

        public override void Cleanup()
        {
        }

        public override GetErrorMessageResponse PerformAction()
        {
            return Service.GetErrorMessage(_request)
                        .GetAwaiter()
                        .GetResult();
        }

        public override void VerifyResponse(GetErrorMessageResponse response)
        {
            response.Message.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
