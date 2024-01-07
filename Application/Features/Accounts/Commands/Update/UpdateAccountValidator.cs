using Application.Features.Accounts.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Commands.Update
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountValidator()
        {
            RuleFor(account => account.Id).NotEmpty().GreaterThan(0).WithMessage(AccountsMessages.NotEmpty);
            RuleFor(account => account.AccountType).NotEmpty().WithMessage(AccountsMessages.NotEmpty);
            RuleFor(account => account.Balance).GreaterThanOrEqualTo(0);
            RuleFor(account => account.UserId).NotEmpty().GreaterThan(0).WithMessage(AccountsMessages.NotEmpty);
        }
    }
    }
}
