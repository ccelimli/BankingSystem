using Domain.Entities;
using Domain.Enums;

namespace Application.Services.AccountService;

public interface IAccountService
{
    Task DepositMoney(string IBAN, double amount);
    Task WithdrawMoney(string iban, double amount);
    Task MoneyTransfer(string iban, string targetAccountNumber, double amount);

    Task<Account> GetByAccountNumber(string accountNumber);
    Task<Account> GetByIban(string iban);
    Task BalanceChange(string accountNumber, BalanceChangeType Type, double amount);

}
