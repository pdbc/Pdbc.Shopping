using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using IdentityStore.Core.Extensions;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.ApplicationConfiguration;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.List.Configuration
{
    public class ListApplicationConfigurationsQueryHandler : IQueryAction<ListApplicationConfigurationsQuery, ListApplicationConfigurationsViewModel>
    {
        private readonly IApplicationConfigurationRepository _repository;

        public ListApplicationConfigurationsQueryHandler(IApplicationConfigurationRepository repository)
        {
            _repository = repository;
        }

        public Task<ListApplicationConfigurationsViewModel> Query(ListApplicationConfigurationsQuery queryModel)
        {
            var queryable = _repository.GetApplicationConfigurationsLinkedToAnOperationalEmployerGroup()
                                       .AsNoTracking();

            var entities = ApplyFilters(queryModel, queryable);
            var totalCount = entities.Count();

            var applicationConfigurations = entities.OrderBy(p => p.Name)
                .ApplyPaging(queryModel)
                .ProjectTo<ApplicationConfigurationListItem>()
                .ToList();

            return Task.FromResult(new ListApplicationConfigurationsViewModel
            {
                TotalCount = totalCount,
                ApplicationConfigurations = applicationConfigurations
            });
        }

        private IQueryable<Domain.Model.ApplicationConfiguration> ApplyFilters(ListApplicationConfigurationsQuery queryModel, IQueryable<Domain.Model.ApplicationConfiguration> entities)
        {
            // Only linked to these account
            return entities.Where(x => x.ApplicationId == queryModel.Id);
        }
    }
}