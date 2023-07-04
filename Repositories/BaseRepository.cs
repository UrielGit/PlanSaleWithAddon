using PlanSaleWithAddon.Context;
using PlanSaleWithAddon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void DeleteById(object id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public void Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges(true);
        }

        public TEntity Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
    }
}
