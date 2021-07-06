using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityStore.Core.Data.Repositories;
using IdentityStore.Core.Dto.Application;
using IdentityStore.Core.Dto.ApplicationConfiguration;
using SDWORX.Framework.CQRS;

namespace IdentityStore.Core.CQRS.Application.Update
{
    public class UpdateApplicationCommandHandler : ICommandAction<UpdateApplicationCommand, Domain.Model.Application>
    {
        private readonly IApplicationRepository _repository;
        private readonly IChangesHandler<IUpdateApplication, Domain.Model.Application> _changesHandler;
        private readonly IApplicationConfigurationRepository _applicationConfigurationRepository;
        private readonly IFactory<ICreateApplicationConfiguration, Domain.Model.ApplicationConfiguration> _applicationConfigurationFactory;
        private readonly IChangesHandler<IUpdateApplicationConfiguration, Domain.Model.ApplicationConfiguration> _applicationConfigurationChangesHandler;

        public UpdateApplicationCommandHandler(IApplicationRepository repository,
            IChangesHandler<IUpdateApplication, Domain.Model.Application> changesHandler,
            IApplicationConfigurationRepository applicationConfigurationRepository,
            IFactory<ICreateApplicationConfiguration, Domain.Model.ApplicationConfiguration> applicationConfigurationFactory,
            IChangesHandler<IUpdateApplicationConfiguration, Domain.Model.ApplicationConfiguration> applicationConfigurationChangesHandler
        )
        {
            _repository = repository;
            _changesHandler = changesHandler;
            _applicationConfigurationRepository = applicationConfigurationRepository;
            _applicationConfigurationFactory = applicationConfigurationFactory;
            _applicationConfigurationChangesHandler = applicationConfigurationChangesHandler;
        }

        public Task<Domain.Model.Application> Execute(UpdateApplicationCommand command)
        {
            var domainObject = _repository.GetById(command.Application.Id);
            if (domainObject != null)
            {
                // main changes
                _changesHandler.ApplyChangesTo(domainObject, command.Application);

                var configurationsToRemove = ApplyChangesOnConfigurations(command, domainObject);

                _repository.Update(domainObject);

                // Delete application configurations
                configurationsToRemove.ForEach(n => _applicationConfigurationRepository.Delete(n));

                // update and save changes
            }


            return Task.FromResult( domainObject);
        }

        private List<Domain.Model.ApplicationConfiguration> ApplyChangesOnConfigurations(UpdateApplicationCommand command, Domain.Model.Application domainObject)
        {
            // Application configurations
            var configurationsToRemove = domainObject.ApplicationConfigurations.Where(g =>
                g.OperationalEmployerGroupId == null &&
                !command.Application.DefaultApplicationConfigurations.Exists(p => p.Id == g.Id)).ToList();
            var configurationsToUpdate = command.Application.DefaultApplicationConfigurations.Where(g =>
                domainObject.ApplicationConfigurations.Where(w => w.OperationalEmployerGroupId == null).Select(s => s.Id)
                    .Contains(g.Id)).ToList();
            var configurationsToAdd = command.Application.DefaultApplicationConfigurations.Where(g =>
                !domainObject.ApplicationConfigurations.Where(w => w.OperationalEmployerGroupId == null).Select(s => s.Id)
                    .Contains(g.Id)).ToList();

            // Create application configurations
            foreach (var configuration in configurationsToAdd)
            {
                domainObject.ApplicationConfigurations.Add(_applicationConfigurationFactory.Create(configuration));
            }

            // Update application configurations
            foreach (var configuration in configurationsToUpdate)
            {
                var domainEntity = domainObject.ApplicationConfigurations.FirstOrDefault(n => n.Id == configuration.Id);
                _applicationConfigurationChangesHandler.ApplyChangesTo(domainEntity, configuration);
            }

            return configurationsToRemove;
        }

    }
}
