using Application.Features.Loans.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Helpers;

public class Calculators
{
    public static double LoanInterestRateCalculator(int loanTypeId, double RequestedLoanAmount, int NumberOfInstallments,string selection)
    {
        LoanInterestRate loanInterestRate = new LoanInterestRate();

        double InterestRate = loanInterestRate.Data[loanTypeId];
        double MonthlyInterestRate = InterestRate / 12;
        double MonthlyPaymentAmount = RequestedLoanAmount * MonthlyInterestRate / (1 - Math.Pow(1 + MonthlyInterestRate, -NumberOfInstallments));
        double TotalPaymentAmount = MonthlyPaymentAmount * NumberOfInstallments;
        double TotalRate = TotalPaymentAmount - RequestedLoanAmount;

        double result= selection switch
        {
            "InterestRate" => Math.Round(InterestRate,2),
            "MonthlyPaymentAmount" => Math.Round(MonthlyPaymentAmount,2),
            "TotalPaymentAmount" => Math.Round(TotalPaymentAmount, 2),
            "TotalRate" => Math.Round(TotalRate, 2)
        };
        
        return result;
    }
}
