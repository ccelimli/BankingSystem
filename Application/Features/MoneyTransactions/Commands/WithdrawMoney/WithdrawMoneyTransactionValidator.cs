using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.WithdrawMoney;

public class WithdrawMoneyTransactionValidator : AbstractValidator<WithdrawMoneyTransactionCommand>
{
    public WithdrawMoneyTransactionValidator()
    {
        RuleFor(transaction => transaction.AccountNumber).NotEmpty(); 
        RuleFor(transaction => transaction.Amount).GreaterThan(0);
        RuleFor(transaction => transaction.UserId).GreaterThan(0);
    }
}

