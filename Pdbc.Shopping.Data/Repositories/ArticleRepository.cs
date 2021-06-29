using Microsoft.EntityFrameworkCore;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Repositories
{
    public interface IArticleRepository : IEntityRepository<Article>
    {


    }

    public class ArticleRepository : EntityFrameworkRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ShoppingDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Article> GetEntitiesSet()
        {
            return DbContext.Articles;
        }

    }
}
