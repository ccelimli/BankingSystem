using Application.Features.Accounts.Constants;
using Application.Features.Loans.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Rules;

public class LoanBusinessRules : BaseBusinessRules
{
    private readonly ILoanRepository _loanRepository;

    public LoanBusinessRules(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task LoanMustBePresent(int id)
    {
        Loan? loan = await _loanRepository.GetAsync(predicate: loan => loan.Id == id);

        if (loan is null)
            throw new BusinessException(LoanMessages.NotFound);
    }
}
