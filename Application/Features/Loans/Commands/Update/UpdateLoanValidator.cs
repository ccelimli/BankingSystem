using Application.Features.Loans.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Update
{
    public class UpdateLoanValidator : AbstractValidator<UpdateLoanCommand>
    {
        public UpdateLoanValidator()
        {
            RuleFor(loan => loan.Id).NotEmpty().WithMessage(LoanMessages.NotEmpty);
            RuleFor(loan => loan.LoanStatus).NotEmpty().WithMessage(LoanMessages.NotEmpty);
        }
    }
}
