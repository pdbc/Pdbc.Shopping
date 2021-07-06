using System.Collections.Generic;
using IdentityStore.Core.Dto.TrustbuilderIdentifier;

namespace IdentityStore.Core.CQRS.Application.List.TrustbuilderIdentifier
{
    public class ListApplicationTrustbuilderIdentifiersViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<LinkedTrustbuilderIdentifierListItem> TrustbuilderIdentifiers { get; set; }
    }
}