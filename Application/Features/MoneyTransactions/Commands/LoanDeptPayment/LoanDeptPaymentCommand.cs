using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.LoanDeptPayment;

public class LoanDeptPaymentCommand : IRequest<LoanDeptPaymentResponse>
{
    public int LoanId { get; set; }
    public double Amount { get; set; }
    public string AccountNumber { get; set; }
}
