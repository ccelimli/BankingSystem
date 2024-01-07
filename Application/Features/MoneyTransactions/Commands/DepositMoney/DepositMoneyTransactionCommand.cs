using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.MoneyTransactions.Commands.DepositMoney;

public class DepositMoneyTransactionCommand : IRequest<DepositMoneyTransactionResponse> , ICacheRemoverRequest, ITransactionalRequest,ILoggableRequest
{
    public string? AccountNumber { get; set; }
    public string? IBAN { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetMoneyTransactions";
}
