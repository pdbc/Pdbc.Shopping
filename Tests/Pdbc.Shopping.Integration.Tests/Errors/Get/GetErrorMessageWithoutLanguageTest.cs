using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers.Api.Resources;
using Pdbc.Shopping.Tests.Helpers.Api.Validation;
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
            _request = new GetErrorMessageRequestTestDataBuilder().WithLanguage("");
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
            response.Notifications.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }
    }
}
