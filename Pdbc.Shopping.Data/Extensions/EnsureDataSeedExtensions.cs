using Microsoft.EntityFrameworkCore;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Extensions
{
    public static class EnsureDataSeedExtensions
    {
        public static void EnsureSeedData(this ShoppingDbContext context)
        {

        }

        public static void SetupInitialData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new ArticleBuilder().WithName("Milk (mager)").Build(),
                new ArticleBuilder().WithName("Milk (lactose vrij)").Build()
                );

            modelBuilder.Entity<Store>().HasData(
                new StoreBuilder().WithName("Carrefour Schoten").Build(),
                new StoreBuilder().WithName("Colruyt Merksem").Build()
            );
        }
    }
}