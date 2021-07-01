using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Pdbc.Shopping.Common.Validation;

namespace Pdbc.Shopping.Core.Validation.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static void AddErrorToValidationBag(this ValidationFailure failure, IValidationBag validationBag)
        {
            validationBag.AddError(failure.ErrorCode, failure.ErrorMessage);
        }
    }
}
