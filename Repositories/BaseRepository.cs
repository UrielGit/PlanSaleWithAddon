using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PlanSaleWithAddon.EFCore.Context;
using PlanSaleWithAddon.Repositories._Interfaces;

namespace PlanSaleWithAddon.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _appDbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            
        }

        public virtual void DeleteById(object id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
            
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public virtual void Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
            
        }

        public TEntity Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
    }
}
