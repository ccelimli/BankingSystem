using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Update;

public class UpdateLoanCommand : IRequest<UpdateLoanResponse>
{
    public int Id { get; set; }
    public int LoanStatus { get; set; } 
}
