using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests.ErrorMessages
{
    public abstract class ErrorMessageServiceTest<Result> : IntegrationTest<Result> where Result : ShoppingResponse
    {
        protected IErrorMessagesService Service;

        protected ErrorMessageServiceTest(IErrorMessagesService service, ShoppingDbContext dbContext) : base(dbContext)
        {
            Service = service;
        }
    }
}
