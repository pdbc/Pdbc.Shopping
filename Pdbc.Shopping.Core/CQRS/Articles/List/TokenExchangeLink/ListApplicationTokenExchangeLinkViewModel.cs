using System.Collections.Generic;
using IdentityStore.Core.Dto.TokenExchangeLink;

namespace IdentityStore.Core.CQRS.Application.List.TokenExchangeLink
{
    public class ListApplicationTokenExchangeLinkViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<TokenExchangeLinkListItem> TokenExchangeLinks { get; set; }
    }
}