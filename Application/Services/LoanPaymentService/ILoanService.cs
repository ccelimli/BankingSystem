using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.LoanPaymentService
{
    public interface ILoanService
    {
        Task LoanPaymnet(int loanId, double amount, string acoountNumber);
        Task<Loan> GetByLoan(int loanId, CancellationToken cancellationToken);
    }
}
