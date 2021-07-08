using Pdbc.Shopping.Core.Validation;
using Pdbc.Shopping.Core.Validators.Articles;
using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandValidator : FluentValidationValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator(IArticleCreateDtoValidator articleCreateDtoValidator)
        {
            RuleFor(i => i.Article).SetValidator(articleCreateDtoValidator);
        }
    }
}
