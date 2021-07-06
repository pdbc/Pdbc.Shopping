using System;
using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests.Crash
{
    public abstract class CrashServiceTest : IntegrationTest<ShoppingResponse> 
    {
        protected ICrashService Service;

        protected CrashServiceTest(ICrashService service, ShoppingDbContext dbContext) : base(dbContext)
        {
            Service = service;
        }

        public override ShoppingResponse PerformAction()
        {
            try
            {
                ExecuteAction();
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            return new ShoppingResponse();
        }

        protected Exception Exception { get; set; }

        protected abstract void ExecuteAction();
    }
}
