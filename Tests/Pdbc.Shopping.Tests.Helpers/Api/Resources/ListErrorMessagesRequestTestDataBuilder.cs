using Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors;

namespace Pdbc.Shopping.Tests.Helpers.Api.Resources
{
    public class ListErrorMessagesRequestTestDataBuilder : ListErrorMessagesRequestBuilder
    {
        public ListErrorMessagesRequestTestDataBuilder()
        {
            base.Language = "NL";
        }
    }
}