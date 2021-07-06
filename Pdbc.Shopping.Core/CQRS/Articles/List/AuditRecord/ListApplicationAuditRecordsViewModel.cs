using System.Collections.Generic;
using IdentityStore.Core.Dto.Audit;

namespace IdentityStore.Core.CQRS.Application.List.AuditRecord
{
    public class ListApplicationAuditRecordsViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<AuditListItem> AuditRecords { get; set; }
    }
}