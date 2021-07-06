using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Integration.Tests.Crash;
using Pdbc.Shopping.Integration.Tests.Errors.Get;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.IntegrationTests.Cqrs.Crash
{
    public class CrashGetShoppingExceptionTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetRequiredService<ICrashCqrsService>();
            return new CrashGetShoppingExceptionTest(service, base.Context);
        }
    }
}