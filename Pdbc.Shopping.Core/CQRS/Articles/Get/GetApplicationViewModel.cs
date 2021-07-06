using IdentityStore.Core.Dto.Application;

namespace IdentityStore.Core.CQRS.Application.Get
{
    public class GetApplicationViewModel
    {
        public ApplicationDetail Application { get; set; }
        
        public string DefaultApplicationIconName { get; set; }
    }
}
