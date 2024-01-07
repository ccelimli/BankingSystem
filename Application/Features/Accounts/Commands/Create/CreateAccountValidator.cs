using Application.Features.Accounts.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Commands.Create;

public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountValidator()
    {
        RuleFor(account => account.UserId).NotEmpty().WithMessage(AccountsMessages.NotEmpty);
        RuleFor(account => account.AccountType).NotEmpty().WithMessage(AccountsMessages.NotEmpty);
    }
}
