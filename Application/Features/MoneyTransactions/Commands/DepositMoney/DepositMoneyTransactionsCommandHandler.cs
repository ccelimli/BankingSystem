using Application.Features.MoneyTransactions.Rules;
using Application.Services.AccountService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MoneyTransactions.Commands.DepositMoney;


public class DepositMoneyTransactionsCommandHandler : IRequestHandler<DepositMoneyTransactionCommand, DepositMoneyTransactionResponse>
{
    private readonly IMoneyTransactionRepository _moneyTransactionRepository;
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;
    private readonly IUserService _userService;

    public DepositMoneyTransactionsCommandHandler(IMoneyTransactionRepository moneyTransactionRepository, IMapper mapper, MoneyTransactionBusinessRules _moneyTransactionBusinessRules, IAccountService accountService, IUserService userService)
    {
        _moneyTransactionRepository = moneyTransactionRepository;
        _mapper = mapper;
        _moneyTransactionRepository = moneyTransactionRepository;
        _accountService = accountService;
        _userService = userService;
    }

    public async Task<DepositMoneyTransactionResponse> Handle(DepositMoneyTransactionCommand request, CancellationToken cancellationToken)
    {
        await _userService.CheckUserExistById(request.UserId);
        await _accountService.DepositMoney(request.AccountNumber, request.Amount);

        MoneyTransaction moneyTransaction = _mapper.Map<MoneyTransaction>(request);
        moneyTransaction.TransactionType = TransactionType.DepositMoney;

        await _moneyTransactionRepository.AddAsync(moneyTransaction);
        MoneyTransaction  moneyTransactionResponse= await _moneyTransactionRepository.GetAsync(predicate: a => a.Id == moneyTransaction.Id, cancellationToken: cancellationToken, include: a => a.Include(a => a.User));

        DepositMoneyTransactionResponse response = _mapper.Map<DepositMoneyTransactionResponse>(moneyTransactionResponse);

        return response;
    }
}
