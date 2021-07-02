using System;
using System.Data.Common;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Integration.Tests;
using Pdbc.Shopping.Tests.Helpers;

namespace Pdbc.Shopping.IntegrationTests.Cqrs
{
    public class ShoppingIntegrationTestFixture : BaseSpecification
    {
        protected ShoppingDbContext Context;

        protected IConfiguration Configuration { get; private set; }

        protected virtual bool ShouldLoadTestObjects { get; set; } = true;
        //protected MusicTestsDataObjects MusicObjects { get; private set; } = null;

        protected ServiceProvider ServiceProvider;

        protected TestCaseService TestCaseService;

        protected DateTime TestStartedDatTime;

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
            //    MusicObjects = new MusicTestsDataObjects(Context);
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
            
            ShoppingIntegrationTestBootstrap.BootstrapContainer(services, Configuration);

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

        protected virtual void CleanupActionsAfterTest() { }
    }
}