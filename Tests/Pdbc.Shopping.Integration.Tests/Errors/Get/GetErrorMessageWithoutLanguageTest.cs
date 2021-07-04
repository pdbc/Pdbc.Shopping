using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Integration.Tests.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Integration.Tests.Errors.Get
{
    public class GetErrorMessageWithoutLanguageTest : ErrorMessageServiceTest<GetErrorMessageResponse>
    {
        public GetErrorMessageWithoutLanguageTest(IErrorMessagesService service, ShoppingDbContext dbContext) 
            : base(service, dbContext)
        {
        }

        private GetErrorMessageRequest _request;

        public override void Setup()
        {
            _request = new GetErrorMessageRequest()
            {
                Key = "ErrorCode_Sample",
                Language = ""
            };
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
            response.Message.ShouldBeNull();
            response.Notifications.HasErrors().ShouldBeTrue();
        }
    }
}
