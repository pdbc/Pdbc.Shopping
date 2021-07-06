using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.Delete
{
    public class DeleteApplicationCommand : ICommandModel<Nothing>
    {
        public long Id { get; set; }
    }
}
