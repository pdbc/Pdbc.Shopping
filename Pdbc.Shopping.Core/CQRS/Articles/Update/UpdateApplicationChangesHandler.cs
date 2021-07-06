using IdentityStore.Core.Dto.Application;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.Update
{
    public class UpdateApplicationChangesHandler : IChangesHandler<IUpdateApplication, Domain.Model.Application>
    {
        public void ApplyChangesTo(Domain.Model.Application domainObject, IUpdateApplication model)
        {
            domainObject.Name = model.Name;
            domainObject.Code = model.Code;
            domainObject.ModifiedOn = model.ModifiedOn;
            domainObject.Uri = model.Uri;
            domainObject.IsMultiEmployer = model.IsMultiEmployer;
            domainObject.IsCitrixSupported = model.IsCitrixSupported;
            domainObject.InactiveFromDate = model.InactiveFromDate;
            domainObject.InactiveToDate = model.InactiveToDate;
            domainObject.IsAuthorizationRequired = model.IsAuthorizationRequired;
            domainObject.ApplicationScopeId = model.ApplicationScopeId;
            domainObject.AllowsTokenExchange = model.AllowsTokenExchange;
            domainObject.IconName = model.IconName;
            domainObject.RequiresTranslationForUserIdForApplication = model.RequiresTranslationForUserIdForApplication;
        }
    }
}