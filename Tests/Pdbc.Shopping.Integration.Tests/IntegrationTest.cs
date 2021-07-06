using System;
using System.Transactions;
using Pdbc.Shopping.Api.Contracts.Requests;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests
{
    public abstract class IntegrationTest<TResult> : IIntegrationTest<TResult> where TResult : ShoppingResponse
    {
        protected DateTime TestStartDateTime { get; set; }
        protected ShoppingDbContext DbContext { get; set; }

        protected IntegrationTest(ShoppingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual void Setup()
        {

        }

        public virtual void Run()
        {
            TestStartDateTime = DateTime.Now;
            RunDirectTest();
        }

        private void RunDirectTest()
        {
            TResult result;

            using (var transaction = new TransactionScope())
            {
                result = PerformAction();
                transaction.Complete();
            }

            ResetContext();

            VerifyResponse(result);
        }
        public abstract void Cleanup();

        public abstract TResult PerformAction();

        public abstract void VerifyResponse(TResult response);

        private Boolean CheckActionHasSucceeded()
        {
            CheckActionSucceeded();
            return true;
        }

        public virtual void CheckActionSucceeded()
        {

        }
        

        public virtual void CheckActionAfterNsbHandlingSucceeded()
        {

        }
        
        //public void VerifyResultWithNotification(TResult result, string errorCode)
        //{
        //    result.Notifications.ExpectErrorWithCode(errorCode);
        //}


        private void ResetContext()
        {
            //DbContext = new IdentityStoreDbContext(null, null, null, null);
            //ClearContext();
            //ReloadAllItems();
        }
        
    }
}