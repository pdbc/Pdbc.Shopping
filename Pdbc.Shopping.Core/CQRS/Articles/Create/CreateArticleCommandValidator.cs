using Pdbc.Shopping.Core.Validation;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandValidator : FluentValidationValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
           
        }
    }
}
