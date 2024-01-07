namespace Application.Features.MoneyTransactions.Commands.DepositMoney;

public class DepositMoneyTransactionResponse
{
    public string AccountNumber { get; set; }
    public string IBAN { get; set; }
    public double Amount { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime CreatedDate { get; set; }
}