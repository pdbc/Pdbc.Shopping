using FluentValidation;
using Pdbc.Shopping.Core.Validation;
using Pdbc.Shopping.Core.Validators.Articles;
using Pdbc.Shopping.DTO.Articles;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandValidator : FluentValidationValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator(IArticleCreateDtoValidator articleCreateDtoValidator)
        {
            RuleFor(i => i.Article)
                .NotNull()
                .WithErrorCode(nameof(ErrorResources.ArticleForCreationInvalid))
                .SetValidator(articleCreateDtoValidator);
        }
    }
}
