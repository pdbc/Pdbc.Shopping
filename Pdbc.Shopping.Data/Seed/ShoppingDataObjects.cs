namespace Pdbc.Shopping.Data.Seed
{
    public class ShoppingDataObjects : IHaveDataObjects
    {
        private readonly ShoppingDbContext _context;

        public ShoppingDataObjects(ShoppingDbContext context)
        {
            _context = context;
        }

        public void LoadObjects()
        {
           
        }
    }
}