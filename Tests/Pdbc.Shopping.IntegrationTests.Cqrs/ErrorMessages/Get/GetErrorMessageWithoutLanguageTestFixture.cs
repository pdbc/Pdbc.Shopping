using Microsoft.Extensions.DependencyInjection;
using Pdbc.Music.Api.Contracts;
using Pdbc.Music.Integration.Tests;
using Pdbc.Music.Integration.Tests.ErrorMessages.Get;
using Pdbc.Music.Integration.Tests.Errors.Get;

namespace Pdbc.Music.Core.IntegrationTests.CQRS.Errors.Get
{
    public class GetErrorMessageWithoutLanguageTestFixture : ShoppingIntegrationCqrsRequestTestFixture
    {
        protected override IIntegrationTest CreateIntegrationTest()
        {
            var service = ServiceProvider.GetService<IErrorMessagesService>();
            return new GetErrorMessageWithoutLanguageTest(service, base.Context);
        }
    }
}