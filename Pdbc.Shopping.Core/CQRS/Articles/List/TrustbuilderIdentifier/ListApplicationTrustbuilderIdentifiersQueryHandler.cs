using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using IdentityStore.Core.Extensions;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.TrustbuilderIdentifier;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.List.TrustbuilderIdentifier
{
    public class ListApplicationTrustbuilderIdentifiersQueryHandler : IQueryAction<ListApplicationTrustbuilderIdentifiersQuery, ListApplicationTrustbuilderIdentifiersViewModel>
    {
        private readonly ILinkedTrustbuilderIdentifierRepository _repository;

        public ListApplicationTrustbuilderIdentifiersQueryHandler(ILinkedTrustbuilderIdentifierRepository repository)
        {
            _repository = repository;
        }

        public Task<ListApplicationTrustbuilderIdentifiersViewModel> Query(ListApplicationTrustbuilderIdentifiersQuery queryModel)
        {
            var entities = _repository.GetTrustbuilderIdentifierLinkedApplication(queryModel.Id)
                                      .AsNoTracking();

            var totalCount = entities.Count();

            var applicationTrustbuilderIdentifiers = entities.OrderBy(p => p.TrustbuilderId)
                .ApplyPaging(queryModel)
                .ProjectTo<LinkedTrustbuilderIdentifierListItem>()
                .ToList();

            return Task.FromResult(new ListApplicationTrustbuilderIdentifiersViewModel
            {
                TotalCount = totalCount,
                TrustbuilderIdentifiers = applicationTrustbuilderIdentifiers
            });
        }
    }
}