using Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Integration.Tests.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Integration.Tests.Errors.List
{
    public class ListErrorMessagesTest : ErrorMessageServiceTest<ListErrorMessagesResponse>
    {
        public ListErrorMessagesTest(IErrorMessagesService service, ShoppingDbContext dbContext) 
            : base(service, dbContext)
        {
        }

        private ListErrorMessagesRequest _request;

        public override void Setup()
        {
            _request = new ListErrorMessagesRequest()
            {
                Language = "NL"
            };
        }

        public override void Cleanup()
        {
        }

        public override ListErrorMessagesResponse PerformAction()
        {
            return Service.ListErrorMessages(_request)
                        .GetAwaiter()
                        .GetResult();
        }

        public override void VerifyResponse(ListErrorMessagesResponse response)
        {
            response.Resources.ShouldNotBeNull();
            response.Resources.Count.ShouldBeGreaterThan(0);
        }
    }
}
