using IdentityStore.Core.Configuration;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.Application;
using SDWORX.Framework.CQRS;
using SDWORX.Framework.Mapping;
using System.Threading.Tasks;

namespace IdentityStore.Core.CQRS.Application.Create
{
    public class CreateApplicationCommandHandler : ICommandAction<CreateApplicationCommand, CreateApplicationResult>
    {
        private readonly IApplicationRepository _repository;
        private readonly IFactory<ICreateApplication, Domain.Model.Application> _factory;
        private readonly IMapper<Domain.Model.Application, ApplicationDetail> _mapper;
        private readonly IIdentityStoreConfiguration _identityStoreConfiguration;

        public CreateApplicationCommandHandler(
            IApplicationRepository repository,
            IFactory<ICreateApplication, Domain.Model.Application> factory, 
            IMapper<Domain.Model.Application, ApplicationDetail> mapper,
            IIdentityStoreConfiguration identityStoreConfiguration)
        {
            _repository = repository;
            _factory = factory;
            _mapper = mapper;
            _identityStoreConfiguration = identityStoreConfiguration;
        }

        public Task<CreateApplicationResult> Execute(CreateApplicationCommand command)
        {
            var entity = _factory.Create(command.Application);
            _repository.Insert(entity);

            return Task.FromResult(new CreateApplicationResult
            {
                Application = _mapper.MapFrom(entity),
                DefaultApplicationIconName = _identityStoreConfiguration.DefaultApplicationIconName
            });

        }
    }
}
