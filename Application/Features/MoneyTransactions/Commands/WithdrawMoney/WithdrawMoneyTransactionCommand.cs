using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.MoneyTransactions.Commands.WithdrawMoney;

public class WithdrawMoneyTransactionCommand : IRequest<WithdrawMoneyTransactionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string AccountNumber { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetMoneyTransactions";
}
