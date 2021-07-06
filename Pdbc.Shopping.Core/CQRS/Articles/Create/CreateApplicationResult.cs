using IdentityStore.Core.Dto.Application;

namespace IdentityStore.Core.CQRS.Application.Create
{
    public class CreateArticleResult
    {
        public ApplicationDetail Application { get; set; }
      
        public string DefaultApplicationIconName { get; set; }
    }
}
