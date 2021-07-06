namespace IdentityStore.Core.CQRS.Application.List.TokenExchangeLink
{
    public class ListApplicationTokenExchangeLinkQuery : IPageableQueryViewModel<ListApplicationTokenExchangeLinkViewModel>
    {
        public long Id { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}