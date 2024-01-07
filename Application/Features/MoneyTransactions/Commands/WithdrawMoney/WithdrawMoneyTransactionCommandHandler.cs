using Application.Features.MoneyTransactions.Rules;
using Application.Services.AccountService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Domain.Entities;

namespace Application.Features.MoneyTransactions.Commands.WithdrawMoney;

public class WithdrawMoneyTransactionCommandHandler : IRequestHandler<WithdrawMoneyTransactionCommand, WithdrawMoneyTransactionResponse>
{
    private readonly IMoneyTransactionRepository _activityRepository;
    private readonly IMapper _mapper;
    private readonly MoneyTransactionBusinessRules _activityBusinessRules;
    private readonly IAccountService _accountService;
    private readonly IUserService _userService;

    public WithdrawMoneyTransactionCommandHandler(IMoneyTransactionRepository activityRepository, IMapper mapper, MoneyTransactionBusinessRules activityBusinessRules, IAccountService accountService, IUserService userService)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
        _activityBusinessRules = activityBusinessRules;
        _accountService = accountService;
        _userService = userService;
    }
    public async Task<WithdrawMoneyTransactionResponse> Handle(WithdrawMoneyTransactionCommand request, CancellationToken cancellationToken)
    {
        await _userService.CheckUserExistById(request.UserId);

        await _accountService.WithdrawMoney(request.AccountNumber, request.Amount);

        MoneyTransaction activity = _mapper.Map<MoneyTransaction>(request);
        activity.TransactionType = TransactionType.WithdrawMoney;

        await _activityRepository.AddAsync(activity);
        WithdrawMoneyTransactionResponse response = _mapper.Map<WithdrawMoneyTransactionResponse>(activity);

        return response;
    }
}