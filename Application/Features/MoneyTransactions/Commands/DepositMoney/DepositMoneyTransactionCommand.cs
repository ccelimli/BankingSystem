using MediatR;

namespace Application.Features.MoneyTransactions.Commands.DepositMoney;

public class DepositMoneyTransactionCommand : IRequest<DepositMoneyTransactionResponse>
{
    public string? AccountNumber { get; set; }
    public string? IBAN { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }
}
