using FluentValidation;
using Pdbc.Shopping.Core.Validation;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.Get
{
    public class GetErrorMessageQueryValidator : FluentValidationValidator<GetErrorMessageQuery>, IValidationBagValidator<GetErrorMessageQuery>
    {
        public GetErrorMessageQueryValidator()
        {
            RuleFor(i => i.Language)
                .NotEmpty()
                .WithErrorCode(nameof(ErrorResources.LanguageIsEmpty));

            RuleFor(i => i.Key)
                .NotEmpty()
                .WithErrorCode(nameof(ErrorResources.ResourceKeyIsEmpty));
        }
    }
}