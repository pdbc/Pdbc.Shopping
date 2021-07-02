using Pdbc.Shopping.Api.Contracts.Requests.Health;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Tests.Helpers.Api.Health;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Integration.Tests.Health.LifelineCheck
{
    public class LifelineCheckTest : HealthCheckServiceTest<LifelineCheckResponse>
    {
        public LifelineCheckTest(IHealthCheckService service, ShoppingDbContext dbContext) 
            : base(service, dbContext)
        {
        }

        private LifelineCheckRequest _request;

        public override void Setup()
        {
            _request = new LifelineCheckRequestTestDataBuilder();
        }

        public override void Cleanup()
        {
        }

        public override LifelineCheckResponse PerformAction()
        {
            return Service.LifelineCheck(_request)
                        .GetAwaiter()
                        .GetResult();
        }

        public override void VerifyResponse(LifelineCheckResponse response)
        {
            response.ShouldNotBeNull();
            response.Notifications.HasErrors().ShouldBeFalse();
        }
    }
}
