using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Update;

public class UpdateLoanCommand : IRequest<UpdateLoanResponse> , ICacheRemoverRequest, ITransactionalRequest, ILoggableRequest
{
    public int Id { get; set; }
    public int LoanStatus { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;

    public string? CacheGroupKey => "GetLoans";
}
