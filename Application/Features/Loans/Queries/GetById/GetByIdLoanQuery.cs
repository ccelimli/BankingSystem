using Application.Features.Accounts.Queries.GetById;
using Application.Features.Accounts.Rules;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Queries.GetById;

public  class GetByIdLoanQuery : IRequest<GetByIdLoanResponse>
{
    public int Id { get; set; }
}
