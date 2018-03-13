using System.Linq;
using TravelApp.DAL.Context;
using TravelApp.DAL.Interface;
using System.Data.Entity;

namespace TravelApp.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TravelContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(TravelContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(params object[] id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public TEntity GetById(params object[] id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public IQueryable<TEntity> Query()
        {
            return dbSet.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
