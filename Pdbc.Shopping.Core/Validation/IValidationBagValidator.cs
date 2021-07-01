using System.Threading.Tasks;
using FluentValidation;
using Pdbc.Shopping.Common.Validation;

namespace Pdbc.Shopping.Core.Validation
{
    public interface IValidationBagValidator<T> : IValidator<T>
    {
        Task Validate(T instance, ValidationBag bag);
    }
}