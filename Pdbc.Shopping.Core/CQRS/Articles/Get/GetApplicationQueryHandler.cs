using IdentityStore.Core.Configuration;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.Application;
using SDWORX.Framework.CQRS;
using SDWORX.Framework.Mapping;
using System.Threading.Tasks;

namespace IdentityStore.Core.CQRS.Application.Get
{
    public class GetApplicationQueryHandler : IQueryAction<GetApplicationQuery, GetApplicationViewModel>
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper<Domain.Model.Application, ApplicationDetail> _mapper;
        private readonly IIdentityStoreConfiguration _identityStoreConfiguration;

        public GetApplicationQueryHandler(IApplicationRepository repository,
            IMapper<Domain.Model.Application, ApplicationDetail> mapper,
            IIdentityStoreConfiguration identityStoreConfiguration)
        {
            _repository = repository;
            _mapper = mapper;
            _identityStoreConfiguration = identityStoreConfiguration;
        }

        public Task<GetApplicationViewModel> Query(GetApplicationQuery queryModel)
        {
            var entity = _repository.GetById(queryModel.Id);
            var applicationScope = _mapper.MapFrom(entity);

            return Task.FromResult( new GetApplicationViewModel
            {
                Application = applicationScope,
                DefaultApplicationIconName = _identityStoreConfiguration.DefaultApplicationIconName
            });
        }
    }
}
