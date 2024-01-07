using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Update;

public class UpdateLoanResponse
{
    public int Id { get; set; }
    public string LoanType { get; set; }
    public double RequestedLoanAmount { get; set; }
    public double TotalPaymentAmount { get; set; }
    public double MonthlyPaymentAmount { get; set; }
    public DateTime MonthlyPaymentDate { get; set; }
    public string LoanStatus { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
}
