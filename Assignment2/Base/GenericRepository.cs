using Assignment2.AsgDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignment2.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AsgDbContext _dbContext;
        public GenericRepository(AsgDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Where(filter).ToList();
        }
    }
}
