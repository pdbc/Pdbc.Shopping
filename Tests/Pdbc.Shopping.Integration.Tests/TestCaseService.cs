using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Integration.Tests
{
    public class TestCaseService
    {
        private readonly ShoppingDbContext _context;

        public TestCaseService(ShoppingDbContext context)
        {
            _context = context;
        }

    }
}
