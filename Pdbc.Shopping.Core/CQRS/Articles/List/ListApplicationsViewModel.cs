using System.Collections.Generic;
using IdentityStore.Core.Dto.Application;

namespace IdentityStore.Core.CQRS.Application.List
{
    public class ListApplicationsViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<ApplicationListItem> Applications { get; set; }

        public string DefaultApplicationIconName { get; set; }
    }
}
