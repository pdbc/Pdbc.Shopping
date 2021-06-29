using Microsoft.EntityFrameworkCore;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Repositories
{
    public interface IStoreRepository : IEntityRepository<Store>
    {


    }

    public class StoreRepository : EntityFrameworkRepository<Store>, IStoreRepository
    {
        public StoreRepository(ShoppingDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Store> GetEntitiesSet()
        {
            return DbContext.Stores;
        }

    }
}
