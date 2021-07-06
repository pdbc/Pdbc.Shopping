using IdentityStore.Core.Data.Repositories;
using SDWORX.Framework.CQRS;
using System.Threading.Tasks;

namespace IdentityStore.Core.CQRS.Application.Delete
{
    public class DeleteApplicationCommandHandler : ICommandAction<DeleteApplicationCommand, Nothing>
    {
        private readonly IApplicationRepository _repository;

        public DeleteApplicationCommandHandler(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public Task<Nothing> Execute(DeleteApplicationCommand command)
        {
            _repository.Delete(command.Id);

            return Task.FromResult(Nothing.AtAll);
        }
    }
}
