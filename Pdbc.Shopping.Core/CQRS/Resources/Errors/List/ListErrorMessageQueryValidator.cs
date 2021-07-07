using FluentValidation;
using Pdbc.Shopping.Core.Validation;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.List
{
    public class ListErrorMessageQueryValidator : FluentValidationValidator<ListErrorMessagesQuery>
    {
        public ListErrorMessageQueryValidator()
        {
            RuleFor(i => i.Language)
                .NotEmpty()
                .WithErrorCode(nameof(ErrorResources.LanguageIsEmpty));
        }
    }
}