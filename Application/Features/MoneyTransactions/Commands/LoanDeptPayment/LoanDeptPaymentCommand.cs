using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Commands.LoanDeptPayment;

public class LoanDeptPaymentCommand : IRequest<LoanDeptPaymentResponse> , ICacheRemoverRequest, ITransactionalRequest,  ILoggableRequest
{
    public int LoanId { get; set; }
    public double Amount { get; set; }
    public string AccountNumber { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetMoneyTransactions";
}
