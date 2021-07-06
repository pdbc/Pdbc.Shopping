using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.Get
{
    public class GetApplicationQuery: IQueryViewModel<GetApplicationViewModel>
    {
        public int Id { get; set; }
    }
}
