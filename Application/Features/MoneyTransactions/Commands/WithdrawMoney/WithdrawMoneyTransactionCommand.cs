using MediatR;

namespace Application.Features.MoneyTransactions.Commands.WithdrawMoney;

public class WithdrawMoneyTransactionCommand : IRequest<WithdrawMoneyTransactionResponse>
{
    public string AccountNumber { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }
}
