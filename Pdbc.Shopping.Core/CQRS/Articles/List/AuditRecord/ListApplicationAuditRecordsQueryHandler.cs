using IdentityStore.Core.CQRS.Audit.List;
using IdentityStore.Domain.Audit.Model;
using SDWORX.Framework.CQRS;
using SDWORX.Framework.Mapping;
using System.Threading.Tasks;

namespace IdentityStore.Core.CQRS.Application.List.AuditRecord
{
    public class ListApplicationAuditRecordsQueryHandler : IQueryAction<ListApplicationAuditRecordsQuery, ListApplicationAuditRecordsViewModel>
    {
        private readonly ICommandMediator _commandMediator;
        private readonly IMapper<ListAuditRecordsViewModel, ListApplicationAuditRecordsViewModel> _mapper;

        public ListApplicationAuditRecordsQueryHandler(ICommandMediator commandMediator,
            IMapper<ListAuditRecordsViewModel, ListApplicationAuditRecordsViewModel> mapper)
        {
            _commandMediator = commandMediator;
            _mapper = mapper;
        }

        public Task<ListApplicationAuditRecordsViewModel> Query(ListApplicationAuditRecordsQuery queryModel)
        {
            var listAuditRecordsQuery = new ListAuditRecordsQueryBuilder()
                .WithAreaType(AuditRecordAreaConstants.Application)
                .WithAreaObjectId(queryModel.Id)
                .WithSearchText(queryModel.SearchText)
                .WithPageCount(queryModel.PageCount)
                .WithPageSize(queryModel.PageSize)
                .Build();

            ListAuditRecordsViewModel listAuditRecordsViewModel = _commandMediator.Query<ListAuditRecordsQuery, ListAuditRecordsViewModel>(listAuditRecordsQuery);
            return Task.FromResult(_mapper.MapFrom(listAuditRecordsViewModel));
        }
    }
}