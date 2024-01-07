using Application.Features.Loans.Commands.Create;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Credit.Commands.Create
{
    public class CreateLoanCommand : IRequest<CreateLoanResponse> , ICacheRemoverRequest , ITransactionalRequest, ILoggableRequest
    {

        public int LoanType { get; set; }
        public double RequestedLoanAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public int UserId { get; set; }

        public string CacheKey => "";
        public bool BypassCache => false;

        public string? CacheGroupKey => "GetLoans";
    }
}
