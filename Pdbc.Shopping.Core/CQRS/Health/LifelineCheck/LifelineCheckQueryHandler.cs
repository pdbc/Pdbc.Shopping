using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Pdbc.Shopping.Core.CQRS.Health.LifelineCheck
{
    public class LifelineCheckQueryHandler : IRequestHandler<LifelineCheckQuery, LifelineCheckViewModel>
    {
        public Task<LifelineCheckViewModel> Handle(LifelineCheckQuery request, CancellationToken cancellationToken)
        {
            var result = new LifelineCheckViewModel()
            {

            };

            return Task.FromResult(result);
        }
    }
}