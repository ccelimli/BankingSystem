using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Queries.GetById
{
    public class GetByIdMoneyTransactionResponse
    {
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public string? TargetAccountNumber { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; } = DateTime.UtcNow;
    }
}
