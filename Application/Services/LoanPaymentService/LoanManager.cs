using Application.Features.Loans.Constants;
using Application.Services.AccountService;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.LoanPaymentService;

public class LoanManager : ILoanService
{
    ILoanRepository _loanRepository;
    IAccountService _accountService;
    IMapper _mapper;

    public LoanManager(ILoanRepository loanRepository, IMapper mapper, IAccountService accountService)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
        _accountService = accountService;
    }

    public async Task<Loan> GetByLoan(int loanId , CancellationToken cancellationToken)
    {
        Loan? loan = await _loanRepository.GetAsync(predicate: loan => loan.Id == loanId, cancellationToken: cancellationToken);
        if (loan is null)
            throw new BusinessException(LoanMessages.NotFound);
      
        else 
            return loan;
    }

    public async Task LoanPaymnet(int loanId, double amount, string accountNumber)
    {
        Loan loan = _mapper.Map<Loan>(_loanRepository.GetAsync(predicate: loan=>loan.Id==loanId));
        Account account = _mapper.Map<Account>(_accountService.GetByAccountNumber(accountNumber));

        if (account.Balance<amount) {
            throw new Exception(LoanMessages.NotEnoughBalance);
        }

        loan.Avail -= amount;
        loan.NumberOfRemainingInstallments -= 1;
        account.Balance -= amount;
        
        await _loanRepository.UpdateAsync(loan);
        await _accountService.BalanceChange(account.AccountNumber,BalanceChangeType.Decrease,amount);
    }
}
