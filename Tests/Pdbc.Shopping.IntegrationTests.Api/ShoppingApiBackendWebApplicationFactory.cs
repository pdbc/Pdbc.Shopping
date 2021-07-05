using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Tests.Helpers;

namespace Pdbc.Shopping.IntegrationTests.Api
{
    public class ShoppingApiBackendWebApplicationFactory : WebApplicationFactory<Pdbc.Shopping.Api.Backend.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ShoppingDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<ShoppingDbContext>(options =>
                {
                    //options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ShoppingDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<ShoppingApiBackendWebApplicationFactory>>();

                    db.Database.EnsureCreated();

                    //try
                    //{
                    //    Utilities.InitializeDbForTests(db);
                    //}
                    //catch (Exception ex)
                    //{
                    //    logger.LogError(ex, "An error occurred seeding the " +
                    //                        "database with test messages. Error: {Message}", ex.Message);
                    //}
                }
            });
        }
    }

}