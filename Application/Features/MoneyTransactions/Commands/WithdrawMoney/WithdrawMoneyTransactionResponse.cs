namespace Application.Features.MoneyTransactions.Commands.WithdrawMoney;

public class WithdrawMoneyTransactionResponse
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }
    public string TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime CreatedDate { get; set; }
}