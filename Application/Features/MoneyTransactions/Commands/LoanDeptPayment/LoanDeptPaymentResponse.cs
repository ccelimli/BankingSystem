using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.LoanDeptPayment
{
    public class LoanDeptPaymentResponse
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string LoanType { get; set; }
        public double TotalPaymentAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public double RequestedLoanAmount { get; set; }
        public double MonthlyPaymentAmount { get; set; }
        public double TotalRate { get; set; }
        public double InterestRate { get; set; }
        public DateTime MonthlyPaymentDate { get; set; }
    }
}
