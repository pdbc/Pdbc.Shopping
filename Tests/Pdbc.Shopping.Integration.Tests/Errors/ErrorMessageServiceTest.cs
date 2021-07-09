using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests.Errors
{
    public abstract class ErrorMessageServiceTest<TResult> : IntegrationTest<TResult> where TResult : ShoppingResponse
    {
        protected IErrorMessagesService Service;

        protected ErrorMessageServiceTest(IErrorMessagesService service, ShoppingDbContext dbContext) : base(dbContext)
        {
            Service = service;
        }
    }
}
