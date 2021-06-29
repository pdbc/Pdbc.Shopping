using Microsoft.EntityFrameworkCore;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Repositories
{
    public interface IAddressRepository : IEntityRepository<Address>
    {


    }

    public class AddressRepository : EntityFrameworkRepository<Address>, IAddressRepository
    {
        public AddressRepository(ShoppingDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Address> GetEntitiesSet()
        {
            return DbContext.Addressses;
        }

    }
}
