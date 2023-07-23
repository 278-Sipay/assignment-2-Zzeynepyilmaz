using System.Linq.Expressions;

namespace Assignment2.Base
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
    }
}
