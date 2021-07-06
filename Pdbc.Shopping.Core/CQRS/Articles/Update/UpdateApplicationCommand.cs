using IdentityStore.Core.Dto.Application;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.Update
{
    public class UpdateApplicationCommand : ICommandModel<Domain.Model.Application>
    {
        public IUpdateApplication Application { get; set; }
    }
}
