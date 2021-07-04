using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Pdbc.Shopping.Core.CQRS.Health.LifelineCheck
{
    public class LifelineCheckCommandHandler : IRequestHandler<LifelineCheckCommand, LifelineCheckResult>
    {
        public Task<LifelineCheckResult> Handle(LifelineCheckCommand request, CancellationToken cancellationToken)
        {
            var result = new LifelineCheckResult()
            {

            };

            return Task.FromResult(result);
        }
    }
}