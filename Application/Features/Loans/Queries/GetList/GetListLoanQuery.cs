using Application.Features.Accounts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Queries.GetList;

public class GetListLoanQuery : IRequest<GetListResponse<GetListLoanListResponse>>
{
    public PageRequest PageRequest { get; set; }
}
