using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Tests.Helpers.Api.Resources
{
    public class GetErrorMessageRequestTestDataBuilder : GetErrorMessageRequestBuilder
    {
        public GetErrorMessageRequestTestDataBuilder()
        {
            base.Language = "NL";
            base.Key = nameof(ErrorResources.LanguageIsEmpty);
        }
    }
}
