using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Repositories
{
    public abstract class EntityFrameworkRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        protected readonly ShoppingDbContext DbContext;

        protected DbSet<TEntity> DbEntities;

        protected EntityFrameworkRepository(ShoppingDbContext dbContext)
        {
            DbContext = dbContext;
            DefineEntitiesSet();
        }

        protected void DefineEntitiesSet()
        {
            DbEntities = GetEntitiesSet();
        }

        protected abstract DbSet<TEntity> GetEntitiesSet();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbEntities;
        }

        public bool Exists(long id)
        {
            return GetById(id) != null;
        }

        public TEntity GetById(long id)
        {
            return DbEntities.Find(id);
        }

        #region Insert
        public void Insert(TEntity newEntity)
        {
            DbEntities.Add(newEntity);
        }
        public async Task InsertAsync(TEntity newEntity)
        {
            await DbEntities.AddAsync(newEntity);
        }
        #endregion

        #region Update
        public void Update(TEntity changedEntity)
        {
            if (DbEntities.Local.All(e => e != changedEntity))
                DbEntities.Attach(changedEntity);
            
            DbContext.Entry(changedEntity).State = EntityState.Modified;
        }

        #endregion


        public void Delete(TEntity removedEntity)
        {
            if (removedEntity != null)
                DbEntities.Remove(removedEntity);
        }

        public void Delete(long removedEntityId)
        {
            var entity = GetById(removedEntityId);
            Delete(entity);
        }
    }
}
