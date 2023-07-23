using Assignment2.Models;
using Assignment2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet("GetByParameter")]
        public IActionResult GetByParameter(
         int? accountNumber,
        decimal? minAmountCredit,
        decimal? maxAmountCredit,
        decimal? minAmountDebit,
        decimal? maxAmountDebit,
        string description,
        DateTime? beginDate,
        DateTime? endDate,
        int? referenceNumber
    )
        {
            Expression<Func<Transaction, bool>> parameter = x =>
             (!accountNumber.HasValue || x.AccountNumber == accountNumber.Value)
             && (!minAmountCredit.HasValue || x.MinAmountCredit >= minAmountCredit.Value)
             && (!maxAmountCredit.HasValue || x.MaxAmountCredit <= maxAmountCredit.Value)
             && (!minAmountDebit.HasValue || x.MinAmountDebit >= minAmountDebit.Value)
             && (!maxAmountDebit.HasValue || x.MaxAmountDebit <= maxAmountDebit.Value)
             && (string.IsNullOrEmpty(description) || x.Description.Contains(description))
             && (!beginDate.HasValue || x.BeginDate >= beginDate.Value)
             && (!endDate.HasValue || x.EndDate <= endDate.Value)
             && (!referenceNumber.HasValue || x.ReferenceNumber == referenceNumber.Value);

            var result = _transactionRepository.GetByParameter(parameter);
            return Ok(result);

        }
    }
}
