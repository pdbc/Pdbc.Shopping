using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Pdbc.Shopping.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static void SafeReload(this DbContext context, object entity)
        {
            try
            {
                context.Entry(entity).Reload();
            }
            catch { }
        }

        public static void DetachAll(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries().Where(x => x.State != EntityState.Detached).ToList();
            foreach (EntityEntry dbEntityEntry in entries)
            {
                if (dbEntityEntry.State != EntityState.Detached)
                {
                    context.Detach(dbEntityEntry.Entity);
                }
            }
        }

        public static void Detach(this DbContext context, object entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }
    }
}