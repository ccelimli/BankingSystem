using Application.Features.MoneyTransactions.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.DepositMoney
{
    public class DepositMoneyTransactionValidator : AbstractValidator<DepositMoneyTransactionCommand>
    {
        public DepositMoneyTransactionValidator()
        {
            RuleFor(transaction => transaction.AccountNumber).NotEmpty().WithMessage(MoneyTransactionMessage.NotEmpty);
            RuleFor(transaction => transaction.IBAN).NotEmpty().WithMessage(MoneyTransactionMessage.NotEmpty);
            RuleFor(transaction => transaction.Amount).GreaterThan(0);
            RuleFor(transaction => transaction.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
