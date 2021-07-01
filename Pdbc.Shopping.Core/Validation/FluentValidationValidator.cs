using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.Validation.Extensions;

namespace Pdbc.Shopping.Core.Validation
{
    /// <summary>
    /// Fluent Validator implementation and map errors to scoped ValidationBag
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FluentValidationValidator<T> : AbstractValidator<T>, IValidationBagValidator<T>
    {
        public Task Validate(T instance, ValidationBag bag)
        {
            var result = base.Validate(instance);
            foreach (var error in result.Errors)
            {
                error.AddErrorToValidationBag(bag);
            }
            return Task.CompletedTask;
        }
    }
}
