using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Pdbc.Shopping.Core.Validation;
using Pdbc.Shopping.DTO.Articles;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.Validators.Articles
{
    public interface IArticleCreateDtoValidator : IValidator<IArticleCreateDto>
    {
    }

    public class ArticleCreateDtoValidator : FluentValidationValidator<IArticleCreateDto>, IArticleCreateDtoValidator
    {
        public ArticleCreateDtoValidator()
        {
            RuleFor(i => i)
                .NotNull()
                .WithErrorCode(nameof(ErrorResources.ArticleForCreationInvalid));

            RuleFor(i => i.Name)
                .NotEmpty()
                .WithErrorCode(nameof(ErrorResources.ArticleNameIsRequired));
        }
    }
}
