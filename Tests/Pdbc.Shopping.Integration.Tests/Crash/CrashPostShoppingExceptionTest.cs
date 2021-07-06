using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.Integration.Tests.Crash
{
    public class CrashPostShoppingExceptionTest : CrashServiceTest
    {
        public CrashPostShoppingExceptionTest(ICrashService service, ShoppingDbContext dbContext)
            : base(service, dbContext)
        {
        }

        public override void Setup()
        {

        }

        public override void Cleanup()
        {
        }

        protected override void ExecuteAction()
        {
            Service.CrashPost(0).GetAwaiter().GetResult();
        }

        public override void VerifyResponse(ShoppingResponse response)
        {
            Exception.ShouldNotBeNull();
            Exception.Message.ShouldBeEqualTo(nameof(ErrorResources.UnexpectedGeneralError));
        }
    }
}