using Core.Persistence.Repositories;
using Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities;

public class Loan : Entity<int>
{
    public LoanType LoanType{ get; set; }    
    public double TotalPaymentAmount { get; set; }
    public int NumberOfInstallments { get; set; }
    public double RequestedLoanAmount { get; set; }
    public double MonthlyPaymentAmount { get; set; }
    public double TotalRate { get; set; }
    public double InterestRate { get; set; }
    public double Avail { get; set; }
    public int NumberOfRemainingInstallments { get; set; }
    public DateTime MonthlyPaymentDate { get; set; }
    public LoanStatus LoanStatus { get; set; } = LoanStatus.Checking;
    public int UserId { get; set; }


    public User User { get; set; }  
}
