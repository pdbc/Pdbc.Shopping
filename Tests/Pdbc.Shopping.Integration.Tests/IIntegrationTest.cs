namespace Pdbc.Shopping.Integration.Tests
{
    public interface IIntegrationTest
    {
        void Setup();

        void Run();

        void Cleanup();
    }

    public interface IIntegrationTest<TResult> : IIntegrationTest
    {
        TResult PerformAction();

        void VerifyResponse(TResult result);

       // void VerifyResultWithNotification(TResult result, string errorCode);
    }
}
