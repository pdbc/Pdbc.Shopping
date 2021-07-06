using FluentValidation;
using IdentityStore.Core.BusinessRules.SDFW;
using IdentityStore.Core.CQRS.Validators.Rules;
using IdentityStore.Core.Dto.Application;
using IdentityStore.I18N;

namespace IdentityStore.Core.CQRS.Application.Update
{
    public class UpdateApplicationCommandValidator : FluentValidationValidator<UpdateApplicationCommand>
    {

        public UpdateApplicationCommandValidator(ISubValidator<ICreateApplication> createApplicationValidator, 
            ISubValidator<IUpdateApplication> updateApplicationValidator,
            IApplicationBusinessRules businessRules) 
        {
            RuleFor(i => i.Application).CompliesWithSubValidator(createApplicationValidator);
            RuleFor(i => i.Application).CompliesWithSubValidator(updateApplicationValidator);


            RuleFor(i => i.Application.Id).Must(businessRules.Exists)
                .WithErrorMessage(nameof(Notifications.ApplicationWithIdDoesNotExists));

            RuleFor(i => i.Application).Must(businessRules.HaveAUniqueCode)
                .WithErrorMessage(nameof(Notifications.DuplicateApplicationCode));

        }
        
    }
}
