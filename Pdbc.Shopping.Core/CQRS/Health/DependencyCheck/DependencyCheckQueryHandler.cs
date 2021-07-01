using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pdbc.Shopping.Core.CQRS.Health.LifelineCheck;

namespace Pdbc.Shopping.Core.CQRS.Health.DependencyCheck
{
    public class DependencyCheckQueryHandler : IRequestHandler<DependencyCheckQuery, DependencyCheckViewModel>
    {
        public Task<DependencyCheckViewModel> Handle(DependencyCheckQuery request, CancellationToken cancellationToken)
        {
            var result = new DependencyCheckViewModel()
            {
            };

            return Task.FromResult(result);
        }
    }
}