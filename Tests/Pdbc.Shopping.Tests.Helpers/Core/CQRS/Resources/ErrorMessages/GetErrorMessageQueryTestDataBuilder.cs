using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.Get;

namespace Pdbc.Shopping.Tests.Helpers.Core.CQRS.Resources.ErrorMessages
{
    public class GetErrorMessageQueryTestDataBuilder : GetErrorMessageQueryBuilder
    {
        public GetErrorMessageQueryTestDataBuilder()
        {
            Key = "Label_Name";
            Language = "nl";
        }
    }
}
