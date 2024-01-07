using Application.Features.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Helpers;

public class Generators
{
    private static readonly Random _random = new Random();
    public static string AccountNumberGenerator()
    {
        string AccountCode = new string(Enumerable.Repeat(AccountConstant.CHARACTER, 8)
            .Select(s => s[_random.Next(s.Length)]).ToArray());

        return $"{AccountConstant.BANK_ACCOUNT_CODE}{AccountCode}";
    }

    public static string IbanGenerator()
    {
        string IbanCode = new string(Enumerable.Repeat(AccountConstant.CHARACTER, 21)
            .Select(s => s[_random.Next(s.Length)]).ToArray());

        return $"{AccountConstant.COUNTRY_CODE_TR}{AccountConstant.BANK_IBAN_CODE}{IbanCode}";
    }
}

