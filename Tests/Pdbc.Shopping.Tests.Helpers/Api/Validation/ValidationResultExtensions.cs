using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Tests.Helpers.Api.Validation
{
    public static class ValidationResultExtensions
    {
        public static void ExpectNoErrors(this ValidationResult entity)
        {
            entity.HasErrors().ShouldBeFalse();
        }

        public static ValidationResult ExpectAnError(this ValidationResult entity)
        {
            entity.HasErrors().ShouldBeTrue("At least on error was expected in the ValidationBag");
            return entity;
        }

        public static ValidationResult ExpectNumberOfErrors(this ValidationResult entity, int count)
        {
            entity.Messages.Count().ShouldBeEqualTo(count);
            return entity;
        }

        public static ValidationResult ExpectErrorWithCode(this ValidationResult entity, String code)
        {
            entity.Messages.FirstOrDefault(x => x.Key == code).ShouldNotBeNull();
            return entity;
        }

        public static ValidationResult ExpectNoErrorWithCode(this ValidationResult entity, String code)
        {
            entity.Messages.FirstOrDefault(x => x.Key == code).ShouldBeNull();
            return entity;
        }
    }
}
