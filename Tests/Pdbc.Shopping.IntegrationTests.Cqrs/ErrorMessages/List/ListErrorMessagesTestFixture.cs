using Microsoft.Extensions.DependencyInjection;
using Pdbc.Music.Api.Contracts;
using Pdbc.Music.Integration.Tests;
using Pdbc.Music.Integration.Tests.Errors.List;

namespace Pdbc.Music.Core.IntegrationTests.CQRS.ErrorMessages.List
{
    public class ListErrorMessagesTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetService<IErrorMessagesService>();
            return new ListErrorMessagesTest(service, base.Context);
        }
    }
}