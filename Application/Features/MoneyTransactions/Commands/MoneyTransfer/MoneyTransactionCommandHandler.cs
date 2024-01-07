using Application.Services.AccountService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MoneyTransactions.Commands.MoneyTransfer;

public class MoneyTransactionCommandHandler : IRequestHandler<MoneyTransactionCommand, MoneyTransactionResponse>
{
    private readonly IMoneyTransactionRepository _moneyTransactionRepository;
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;
    private readonly IUserService _userService;

    public MoneyTransactionCommandHandler(IMoneyTransactionRepository moneyTransactionRepository, IMapper mapper, IAccountService accountService, IUserService userService)
    {
        _moneyTransactionRepository = moneyTransactionRepository;
        _mapper = mapper;
        _accountService = accountService;
        _userService = userService;
    }

    public async Task<MoneyTransactionResponse> Handle(MoneyTransactionCommand request, CancellationToken cancellationToken)
    {
        await _userService.CheckUserExistById(request.UserId);
        await _accountService.MoneyTransfer(request.AccountNumber, request.TargetAccountNumber, request.Amount);

        MoneyTransaction moneyTransaction = _mapper.Map<MoneyTransaction>(request);
        moneyTransaction.TransactionType = TransactionType.MoneyTransfer;

        await _moneyTransactionRepository.AddAsync(moneyTransaction);
        MoneyTransaction moneyTransactionResponse= await _moneyTransactionRepository.GetAsync(predicate: a => a.Id == moneyTransaction.Id, cancellationToken: cancellationToken, include: a => a.Include(a => a.User));

        MoneyTransactionResponse response = _mapper.Map<MoneyTransactionResponse>(moneyTransactionResponse);

        return response;
    }
}