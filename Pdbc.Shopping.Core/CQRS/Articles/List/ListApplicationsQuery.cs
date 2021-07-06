namespace IdentityStore.Core.CQRS.Application.List
{
    public class ListApplicationsQuery: IPageableQueryViewModel<ListApplicationsViewModel>
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }

        public string SearchText { get; set; }
    }
}
