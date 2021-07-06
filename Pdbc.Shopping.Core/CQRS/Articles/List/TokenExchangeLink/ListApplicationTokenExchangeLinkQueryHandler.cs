using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using IdentityStore.Core.Extensions;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.TokenExchangeLink;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.List.TokenExchangeLink
{
    public class ListApplicationTokenExchangeLinkQueryHandler : IQueryAction<ListApplicationTokenExchangeLinkQuery, ListApplicationTokenExchangeLinkViewModel>
    {
        private readonly ITokenExchangeLinkRepository _repository;

        public ListApplicationTokenExchangeLinkQueryHandler(ITokenExchangeLinkRepository repository)
        {
            _repository = repository;
        }

        public Task<ListApplicationTokenExchangeLinkViewModel> Query(ListApplicationTokenExchangeLinkQuery queryModel)
        {
            var entities = _repository.GetTokenExchangeLinkedToApplication(queryModel.Id)
                                      .AsNoTracking();

            var totalCount = entities.Count();

            var applicationTokenExchangeLinkListItems = entities.OrderBy(p => p.TargetTrustbuilderId)
                .ApplyPaging(queryModel)
                .ProjectTo<TokenExchangeLinkListItem>()
                .ToList();

            return Task.FromResult(new ListApplicationTokenExchangeLinkViewModel
            {
                TotalCount = totalCount,
                TokenExchangeLinks = applicationTokenExchangeLinkListItems
            });
        }
    }
}