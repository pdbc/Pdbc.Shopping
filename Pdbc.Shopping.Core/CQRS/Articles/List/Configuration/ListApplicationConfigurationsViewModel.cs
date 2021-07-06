using System.Collections.Generic;
using IdentityStore.Core.Dto.ApplicationConfiguration;

namespace IdentityStore.Core.CQRS.Application.List.Configuration
{
    public class ListApplicationConfigurationsViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<ApplicationConfigurationListItem> ApplicationConfigurations { get; set; }
    }
}