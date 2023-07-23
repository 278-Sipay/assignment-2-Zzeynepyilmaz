using Assignment2.Base;
using Assignment2.Models;
using System.Linq.Expressions;

namespace Assignment2.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        IEnumerable<Transaction> GetByParameter(Transaction parameter);
    }
}
