using Core.Application.Rules;

namespace Application.Features.Accounts.Constants;

public class AccountsMessages : BaseBusinessRules
{
    public const string NotEmpty = "Bilgiler Boş Olamaz!";
    public const string AccountNumberExists = "Account number exists";
    public const string AccountNotFound = "Account not found";
    public const string TargetAccountNotFound = "Target account not found";
    public const string AccountAssociatedUserNotFound = "Account associated user not found";
    public const string AccountBalanceIsNotEnough = "Account balance is not enough";
}