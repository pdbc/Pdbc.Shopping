using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pdbc.Shopping.Core.CQRS.Health.LifelineCheck;

namespace Pdbc.Shopping.Core.CQRS.Health.DependencyCheck
{
    public class DependencyCheckCommandHandler : IRequestHandler<DependencyCheckCommand, DependencyCheckResult>
    {
        public Task<DependencyCheckResult> Handle(DependencyCheckCommand request, CancellationToken cancellationToken)
        {
            var result = new DependencyCheckResult()
            {
            };

            return Task.FromResult(result);
        }
    }
}