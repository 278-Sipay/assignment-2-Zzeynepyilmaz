using Assignment2.Base;
using Assignment2.Models;
using Assignment2.AsgDbContext;
using System.Linq.Expressions;

namespace Assignment2.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly AsgDbContext _dbcontext;
        public TransactionRepository(AsgDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public IEnumerable<Transaction> GetByParameter(Transaction parameter)
        {
            Expression<Func<Transaction, bool>> expression = transaction =>
                (parameter.AccountNumber == null || transaction.AccountNumber == parameter.AccountNumber) && 
                (parameter.ReferenceNumber == null || transaction.ReferenceNumber == parameter.ReferenceNumber) && 
                (parameter.MinAmountCredit == null || transaction.MinAmountCredit >= parameter.MinAmountCredit) &&
                (parameter.MaxAmountCredit == null || transaction.MaxAmountCredit <= parameter.MaxAmountCredit) && 
                (parameter.MinAmountDebit == null || transaction.MinAmountDebit >= parameter.MinAmountDebit) &&
                (parameter.MaxAmountDebit == null || transaction.MaxAmountDebit <= parameter.MaxAmountDebit) && 
                (parameter.Description == null || transaction.Description.Contains(parameter.Description)) && 
                (parameter.BeginDate == null || transaction.BeginDate >= parameter.BeginDate) &&
                (parameter.EndDate == null || transaction.EndDate <= parameter.EndDate); 


            return GetByParameter(parameter);
        }
    }
}
