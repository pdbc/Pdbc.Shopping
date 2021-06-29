using Microsoft.EntityFrameworkCore;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Repositories
{
    public interface IShoppingListRepository : IEntityRepository<ShoppingList>
    {


    }

    public class ShoppingListRepository : EntityFrameworkRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(ShoppingDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<ShoppingList> GetEntitiesSet()
        {
            return DbContext.ShoppingLists;
        }

    }
}
