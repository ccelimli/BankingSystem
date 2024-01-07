using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Queries.GetList
{
    public class GetListMoneyTransactionDto
    {
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public string? TargetAccountNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; } = DateTime.UtcNow;
    }
}
