using IdentityStore.Core.Dto.Application;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.Create
{
    public class CreateApplicationCommandFactory : IFactory<ICreateApplication, Domain.Model.Application>
    {
        public Domain.Model.Application Create(ICreateApplication model)
        {
            var builder = new Domain.Model.ApplicationBuilder()
                    .WithCode(model.Code)
                    .WithName(model.Name)
                    .WithUri(model.Uri)
                    //.WithGracePeriodInMonths(model.GracePeriodInMonths)
                    .WithIsMultiEmployer(model.IsMultiEmployer)
                    .WithIsCitrixSupported(model.IsCitrixSupported)
                    .WithApplicationScopeId(model.ApplicationScopeId)
                    .WithInactiveFromDate(model.InactiveFromDate)
                    .WithInactiveToDate(model.InactiveToDate)
                    .WithIsAuthorizationRequired(model.IsAuthorizationRequired)
                    .WithAllowsTokenExchange(model.AllowsTokenExchange)
                    .WithRequiresTranslationForUserIdForApplication(model.RequiresTranslationForUserIdForApplication)
                    .WithIconName(model.IconName)
                ;

            foreach (var localized in model.DefaultApplicationConfigurations)
            {
                var nameBuilder = new Domain.Model.ApplicationConfigurationBuilder()
                        .WithLanguageCode(localized.LanguageCode)
                        .WithName(localized.Name)
                        .WithUri(localized.Uri)
                        .WithOperationalEmployerGroupId(localized.OperationalEmployerGroupId)
                        .Build();

                builder.AddApplicationConfigurationsItem(nameBuilder);
            }

            return builder.Build();
        }
    }
}
