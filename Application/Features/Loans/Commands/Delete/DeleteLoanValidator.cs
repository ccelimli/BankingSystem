using Application.Features.Loans.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Delete
{
    public class DeleteLoanValidator : AbstractValidator<DeleteLoanCommand>
    {
        public DeleteLoanValidator()
        {
            RuleFor(loan => loan.Id).NotEmpty().WithMessage(LoanMessages.NotEmpty);
        }
    }
}
