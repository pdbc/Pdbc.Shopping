using Pdbc.Shopping.Data;
using Pdbc.Shopping.Data.Seed;

namespace Pdbc.Shopping.IntegrationTests.Cqrs
{
    public class ShoppingTestDataObjects : IHaveDataObjects
    {
        public ShoppingDataObjects ShoppingDataObjects { get; private set; }
        
        public ShoppingTestDataObjects(ShoppingDbContext musicDbContext)
        {
            ShoppingDataObjects = new ShoppingDataObjects(musicDbContext);
        }

        public void LoadObjects()
        {
            ShoppingDataObjects.LoadObjects();
        }
    }
}