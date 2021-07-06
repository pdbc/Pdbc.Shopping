namespace IdentityStore.Core.CQRS.Application.List.TrustbuilderIdentifier
{
    public class ListApplicationTrustbuilderIdentifiersQuery : IPageableQueryViewModel<ListApplicationTrustbuilderIdentifiersViewModel>
    {
        public long Id { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}