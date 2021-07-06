using FluentValidation;
using IdentityStore.Core.BusinessRules.SDFW;
using IdentityStore.Core.CQRS.Validators.Rules;
using IdentityStore.I18N;

namespace IdentityStore.Core.CQRS.Application.Delete
{
    public class DeleteApplicationCommandValidator : FluentValidationValidator<DeleteApplicationCommand>
    {       
        public DeleteApplicationCommandValidator(IApplicationBusinessRules businessRules) 
        {

            RuleFor(i => i.Id).Must(businessRules.NotBeLinkedToAnyAccessRight).WithErrorMessage(nameof(Notifications.ApplicationHasReferencedData));
        }

    }
}
