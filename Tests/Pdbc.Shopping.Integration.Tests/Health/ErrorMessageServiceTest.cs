using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests.Health
{
    public abstract class HealthCheckServiceTest<Result> : IntegrationTest<Result> where Result : ShoppingResponse
    {
        protected IHealthCheckService Service;

        protected HealthCheckServiceTest(IHealthCheckService service, ShoppingDbContext dbContext) : base(dbContext)
        {
            Service = service;
        }
    }
}
