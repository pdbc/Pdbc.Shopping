namespace IdentityStore.Core.CQRS.Application.List.AuditRecord
{
    public class ListApplicationAuditRecordsQuery : IPageableQueryViewModel<ListApplicationAuditRecordsViewModel>
    {
        public long Id { get; set; }

        public string SearchText { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}