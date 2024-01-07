using Application.Features.Credit.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Create;
public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
{
    public CreateLoanValidator()
    {
        RuleFor(request => request.LoanType).NotEmpty(); 
        RuleFor(request => request.RequestedLoanAmount).GreaterThan(0);
        RuleFor(request => request.NumberOfInstallments).GreaterThan(0);
        RuleFor(request => request.UserId).NotEmpty().GreaterThan(0);
    }
}
