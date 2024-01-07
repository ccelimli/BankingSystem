using Application.Features.Accounts.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services.AccountService;

public class AccountManager : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountManager(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task DepositMoney(string IBAN, double amount)
    {
        Account? account = await _accountRepository.GetAsync(predicate: account => account.IBAN == IBAN);

        if (account is not null)
            account.Balance += amount;
        else
            throw new BusinessException(AccountsMessages.AccountNotFound);

        await _accountRepository.UpdateAsync(account);
    }

    public async Task WithdrawMoney(string IBAN, double amount)
    {
        Account? account = await _accountRepository.GetAsync(predicate: account => account.IBAN == IBAN);

        if (account is not null)
        {
            if (account.Balance < amount)
                throw new BusinessException(AccountsMessages.AccountBalanceIsNotEnough);
            account.Balance -= amount;
        }
        else
            throw new BusinessException(AccountsMessages.AccountNotFound);

        await _accountRepository.UpdateAsync(account);
    }

    public async Task MoneyTransfer(string iban, string targetIBAN, double amount)
    {
        await WithdrawMoney(iban, amount);

        Account? targetAccount = await _accountRepository.GetAsync(predicate: account => account.IBAN == iban);

        if (targetAccount is not null)
            targetAccount.Balance += amount;
        else
            throw new BusinessException(AccountsMessages.TargetAccountNotFound);

        await _accountRepository.UpdateAsync(targetAccount);
    }

    public async Task<Account> GetByAccountNumber(string accountNumber)
    {
        Account? account = await _accountRepository.GetAsync(predicate: account => account.AccountNumber == accountNumber);
        if (account is null )
        {
            throw new BusinessException(AccountsMessages.AccountNotFound);
        }
        else
        {
            return account;
        }
    }
    public async Task<Account> GetByIban(string iban)
    {
        Account? account = await _accountRepository.GetAsync(predicate: account => account.IBAN == iban);
        if (account is null)
        {
            throw new BusinessException(AccountsMessages.AccountNotFound);
        }
        else
        {
            return account;
        }
    }

    public async Task BalanceChange(string accountNumber, BalanceChangeType Type, double amount)
    {
        Account? account = await _accountRepository.GetAsync(predicate: account => account.AccountNumber == accountNumber);

        if (Type == BalanceChangeType.Rise)
        {
            account.Balance+=amount;
        }
        else if( Type == BalanceChangeType.Decrease)
        {
            account.Balance += amount; 
        }
    }
}
