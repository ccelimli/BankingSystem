using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.MoneyTransfer
{
    public class MoneyTransactionValidator : AbstractValidator<MoneyTransactionCommand>
    {
        public MoneyTransactionValidator()
        {
            RuleFor(transaction => transaction.AccountNumber).NotEmpty();
            RuleFor(transaction => transaction.IBAN).NotEmpty();
            RuleFor(transaction => transaction.TargetAccountNumber);
            RuleFor(transaction => transaction.TargetIBAN).NotEmpty();
            RuleFor(transaction => transaction.Amount).GreaterThan(0);
            RuleFor(transaction => transaction.UserId).GreaterThan(0);
            RuleFor(transaction => transaction.TransactionDate).NotEmpty();
        }
    }
}
