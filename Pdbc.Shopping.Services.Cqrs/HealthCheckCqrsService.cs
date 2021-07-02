using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pdbc.Shopping.Api.Contracts.Requests.Health;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS.Health.LifelineCheck;
using Pdbc.Shopping.Services.Cqrs.Base;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Services.Cqrs
{
    public class HealthCheckCqrsService : CqrsService, IHealthCheckCqrsService, IHealthCheckService
    {
        public HealthCheckCqrsService(IMediator mediator, IMapper mapper, ValidationBag validationBag) 
            : base(mediator, mapper, validationBag)
        {
        }

        public async Task<LifelineCheckResponse> LifelineCheck(LifelineCheckRequest request)
        {
            return await Query<LifelineCheckRequest, LifelineCheckQuery,
                               LifelineCheckViewModel, LifelineCheckResponse>(request);
        }
    }
}
