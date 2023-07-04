using System.Linq.Expressions;

namespace PlanSaleWithAddon.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity entity);
        void DeleteById(object id);
        TEntity Exists(Expression<Func<TEntity, bool>> predicate);

    }
}
