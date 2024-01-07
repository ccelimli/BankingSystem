namespace Application.Features.MoneyTransactions.Commands.MoneyTransfer;

public class MoneyTransactionResponse
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string TargetAccountNumber { get; set; }
    public double Amount { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastNAme { get; set; }
    public string TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime CreatedDate { get; set; }
}