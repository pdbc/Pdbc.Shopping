using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using IdentityStore.Core.Extensions;
using IdentityStore.Core.Configuration;
using IdentityStore.Core.Data.QueryableExtensions;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.Application;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.List
{
    public class ListApplicationsQueryHandler : IQueryAction<ListApplicationsQuery, ListApplicationsViewModel>
    {
        private readonly IApplicationRepository _repository;
        private readonly IIdentityStoreConfiguration _identityStoreConfiguration;

        public ListApplicationsQueryHandler(IApplicationRepository repository, IIdentityStoreConfiguration identityStoreConfiguration)
        {
            _repository = repository;
            _identityStoreConfiguration = identityStoreConfiguration;
        }

        public Task<ListApplicationsViewModel> Query(ListApplicationsQuery queryModel)
        {
            var queryable = _repository.GetAll()
                                       .AsNoTracking();

            var entities = ApplyFilters(queryModel, queryable);
            var totalCount = entities.Count();

            entities = entities.OrderBy(p => p.Name).ApplyPaging(queryModel);

            var applicationScopes = entities.ProjectTo<ApplicationListItem>().ToList();

            return Task.FromResult(new ListApplicationsViewModel
            {
                TotalCount = totalCount,
                Applications = applicationScopes,
                DefaultApplicationIconName = _identityStoreConfiguration.DefaultApplicationIconName
            });
        }

        private IQueryable<Domain.Model.Application> ApplyFilters(ListApplicationsQuery queryModel, IQueryable<Domain.Model.Application> entities)
        {
            if (!string.IsNullOrEmpty(queryModel.SearchText))
            {
                var searchText = queryModel.SearchText.ToLowerInvariant();

                entities = entities.Search(searchText); 
            }

            return entities;
        }
    }
}
