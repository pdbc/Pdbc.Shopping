namespace IdentityStore.Core.CQRS.Application.List.Configuration
{
    public class ListApplicationConfigurationsQuery : IPageableQueryViewModel<ListApplicationConfigurationsViewModel>
    {
        public long Id { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}