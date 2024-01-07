using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        //FirstName
        RuleFor(user => user.FirstName).NotEmpty();
        RuleFor(user => user.FirstName).Must(ControlName);
        RuleFor(user => user.FirstName).MinimumLength(2);

        // LastName
        RuleFor(user => user.LastName).NotEmpty();
        RuleFor(user => user.LastName).Must(ControlName);
        RuleFor(user => user.LastName).MinimumLength(2);

        //PhoneNumber
        RuleFor(user => user.PhoneNumber).NotEmpty();
        RuleFor(user => user.PhoneNumber).Must(ControlPhoneNumber);
        RuleFor(user => user.PhoneNumber).Must(StartWith);
        //PhoneNumber
        RuleFor(user => user.NationalityNo).NotEmpty();
        RuleFor(user => user.NationalityNo).Must(ControlNationalityNo);
        RuleFor(user => user.NationalityNo).Must(StartWith);

        //Email
        RuleFor(user => user.Email).NotEmpty();
        RuleFor(user => user.Email).Must(ControlEmail);
    }

    //Control Name
    private bool ControlName(string arg)
    {
        Regex regex = new Regex(@"^[A-ZİĞÜŞÖÇ][a-zA-ZğüşöçıİĞÜŞÖÇ]*$");
        var result = regex.Match(arg);
        if (result.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Control Email
    private bool ControlEmail(string arg)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        var result = regex.Match(arg);
        if (result.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // ControlPhoneNumber
    private bool ControlPhoneNumber(string arg)
    {
        Regex regex = new Regex(@"^[1-9]{10}$");
        var result = regex.Match(arg);
        if (result.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // ControlPhoneNumber
    private bool ControlNationalityNo(string arg)
    {
        Regex regex = new Regex(@"^[1-9]{11}$");
        var result = regex.Match(arg);
        if (result.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool StartWith(string arg)
    {
        var result = arg.StartsWith("0");
        if (arg.StartsWith("0"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
