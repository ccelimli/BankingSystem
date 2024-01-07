using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Create
{
    public class CreateLoanResponse
    {
        public string LoanType { get; set; }
        public double TotalPaymentAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public double RequestedLoanAmount { get; set; }
        public double MonthlyPaymentAmount { get; set; }
        public double TotalRate { get; set; }
        public double InterestRate { get; set; }
        public DateTime MonthlyPaymentDate { get; set; }
        public string LoanStatus { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }
}
