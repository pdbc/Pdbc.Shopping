using System;
using System.Data.Common;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Pdbc.Shopping.Api.ServiceAgent;
using Pdbc.Shopping.Common.Extensions;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Tests.Helpers;

namespace Pdbc.Shopping.IntegrationTests.Api
{
    /// <inheritdoc />
    public abstract class MusicIntegrationApiRequestTestFixture : BaseSpecification
    {
        protected ShoppingDbContext Context;

        protected IConfiguration Configuration { get; private set; }

        protected virtual bool ShouldLoadTestObjects { get; set; } = true;
        //protected ShoppingTestsDataObjects MusicObjects { get; private set; } = null;

        protected ServiceProvider ServiceProvider;

        protected TestCaseService TestCaseService;

        protected DateTime TestStartedDatTime;
        protected IIntegrationTest IntegrationTest;

        protected abstract IIntegrationTest CreateIntegrationTest();

        protected override void Establish_context()
        {
            LoadConfiguration();

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            var dir = TestContext.CurrentContext.TestDirectory;
            Directory.SetCurrentDirectory(dir);

            SetupServiceProvider();

            Context = ServiceProvider.GetService<ShoppingDbContext>();

            TestCaseService = new TestCaseService(Context);
            //if (ShouldLoadTestObjects)
            //{
            //    MusicObjects = new ShoppingTestsDataObjects(Context);
            //    MusicObjects.LoadObjects();
            //}

            TestStartedDatTime = DateTime.Now;

            base.Establish_context();
        }

        private void SetupServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton(Configuration);
            services.AddLogging();
            //services.AddHttpClient().AddNewtonsoft();

            services.RegisterModule<ShoppingDataModule>(Configuration);
            services.RegisterModule<ShoppingServiceAgentModule>(Configuration);

            ServiceProvider = services.BuildServiceProvider();
        }

        private void LoadConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = configurationBuilder.Build();

        }

        protected override void Dispose_context()
        {
            RunWithoutException(CleanupActionsAfterTest);
            RunWithoutException(() => Context.SaveChanges());
            RunWithoutException(() => Context?.Dispose());
        }

        private void RunWithoutException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception) { }
        }

        protected override void Because()
        {
            //Context.SaveChanges();
            base.Because();
            //Context.SaveChanges();
        }


        [Test]
        public void Execute_Test()
        {
            TestExecutionContext.CurrentContext.OutWriter.WriteLine($"{DateTime.Now:hh:mm:ss.fffffff}: Running {TestExecutionContext.CurrentContext.CurrentTest.FullName}");

            IntegrationTest = CreateIntegrationTest();
            EditApiTest();

            var strategy = Context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using var transaction = Context.Database.BeginTransaction();

                IntegrationTest.Setup();
                Context.SaveChanges();
                transaction.Commit();
            });

            IntegrationTest.Run();
            IntegrationTest.Cleanup();

            // Save changes after cleanup
            Context.SaveChanges();

            TestExecutionContext.CurrentContext.OutWriter.WriteLine($"{DateTime.Now:hh:mm:ss.fffffff}: Finished {TestExecutionContext.CurrentContext.CurrentTest.FullName}");
        }

        protected virtual void EditApiTest()
        {

        }

        protected virtual void CleanupActionsAfterTest()
        {
            if (IntegrationTest != null)
            {
                try
                {
                    IntegrationTest.Cleanup();
                    Context.SaveChanges();
                }
                catch (Exception)
                {
                    //Ignore fails because if the setup fails, this might as well fail.
                }
            }
        }

    }

}
