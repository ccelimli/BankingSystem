using Application.Features.Accounts.Queries.GetById;
using Application.Features.Accounts.Rules;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Queries.GetById;

public  class GetByIdLoanQuery : IRequest<GetByIdLoanResponse>, ICacheableRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string CacheKey => "";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetLoans";
}
