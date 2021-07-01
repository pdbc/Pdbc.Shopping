using FluentValidation;
using Pdbc.Music.Core.CQRS.ErrorMessages.Get;
using Pdbc.Shopping.Core.Validation;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get
{
    public class GetErrorMessageQueryValidator : FluentValidationValidator<GetErrorMessageQuery>, IValidationBagValidator<GetErrorMessageQuery>
    {
        public GetErrorMessageQueryValidator()
        {
            RuleFor(i => i.Language)
                .NotEmpty()
                .WithErrorCode(nameof(ErrorResources.LanguageIsEmpty));

            RuleFor(i => i.Key)
                .NotEmpty();
        }
    }
}