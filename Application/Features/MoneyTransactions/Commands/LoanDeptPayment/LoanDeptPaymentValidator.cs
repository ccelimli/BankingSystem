using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.LoanDeptPayment
{
    public class LoanDeptPaymentValidator : AbstractValidator<LoanDeptPaymentCommand>
    {
        public LoanDeptPaymentValidator()
        {
            RuleFor(payment => payment.LoanId).GreaterThan(0);
            RuleFor(payment => payment.Amount).GreaterThan(0);
            RuleFor(payment => payment.AccountNumber).NotEmpty();
        }
    }
}
