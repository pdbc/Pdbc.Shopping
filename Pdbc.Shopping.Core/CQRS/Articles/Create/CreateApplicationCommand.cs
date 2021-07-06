using IdentityStore.Core.CQRS.Application.Create;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommand : ICommand<CreateArticleResult> 
    {
        public ICreateApplication Application { get; set; }
    }
}
