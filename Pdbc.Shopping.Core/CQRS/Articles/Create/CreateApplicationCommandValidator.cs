using FluentValidation;
using IdentityStore.Core.BusinessRules.SDFW;
using IdentityStore.Core.CQRS.Validators.Rules;
using IdentityStore.Core.Dto.Application;
using IdentityStore.I18N;

namespace IdentityStore.Core.CQRS.Application.Create
{
    public class CreateApplicationCommandValidator : FluentValidationValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator(ISubValidator<ICreateApplication> createApplicationValidator,
                                                 IApplicationBusinessRules businessRules)
        {
            RuleFor(i => i.Application).CompliesWithSubValidator(createApplicationValidator);

            // Extra validation specific 
            RuleFor(i => i.Application.Code)
                .Must(businessRules.HaveAUniqueCode)
                .WithErrorMessage(nameof(Notifications.DuplicateApplicationCode));
        }

    }
}
