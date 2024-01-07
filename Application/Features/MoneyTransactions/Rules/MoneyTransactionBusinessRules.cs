using Application.Services.Repositories;
using Core.Application.Rules;

namespace Application.Features.MoneyTransactions.Rules;

public class MoneyTransactionBusinessRules : BaseBusinessRules
{
    private readonly IMoneyTransactionRepository _moneyTransactionRepository;

    public MoneyTransactionBusinessRules(IMoneyTransactionRepository moneyTransactionRepository)
    {
        _moneyTransactionRepository = moneyTransactionRepository;
    }
}