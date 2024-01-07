using Application.Features.Loans.Commands.Create;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Credit.Commands.Create
{
    public class CreateLoanCommand : IRequest<CreateLoanResponse>
    {

        public int LoanType { get; set; }
        public double RequestedLoanAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public int UserId { get; set; }
    }
}
