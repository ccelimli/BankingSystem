using Application.Features.MoneyTransactions.Commands.MoneyTransfer;
using Application.Services.AccountService;
using Application.Services.LoanPaymentService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.LoanDeptPayment;

public class LoanDeptPaymentCommandHandler : IRequestHandler<LoanDeptPaymentCommand, LoanDeptPaymentResponse>
{
    private readonly IMoneyTransactionRepository _moneyTransactionRepository;
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;
    private readonly ILoanService _loanService;

    public LoanDeptPaymentCommandHandler(IMoneyTransactionRepository moneyTransactionRepository, IMapper mapper, IAccountService accountService, IUserService userService, ILoanService loanService)
    {
        _moneyTransactionRepository = moneyTransactionRepository;
        _mapper = mapper;
        _accountService = accountService;
        _loanService = loanService;
    }

    public async Task<LoanDeptPaymentResponse> Handle(LoanDeptPaymentCommand request, CancellationToken cancellationToken)
    {
        await _accountService.GetByAccountNumber(request.AccountNumber);
        await _loanService.LoanPaymnet(request.LoanId, request.Amount, request.AccountNumber);

        MoneyTransaction moneyTransaction = _mapper.Map<MoneyTransaction>(request);
        moneyTransaction.TransactionType = TransactionType.LoanPayment;

        await _moneyTransactionRepository.AddAsync(moneyTransaction);
        Loan loanResponse = _mapper.Map<Loan>(_loanService.GetByLoan(request.LoanId, cancellationToken));

        LoanDeptPaymentResponse response = _mapper.Map<LoanDeptPaymentResponse>(loanResponse);

        return response;
    }
}