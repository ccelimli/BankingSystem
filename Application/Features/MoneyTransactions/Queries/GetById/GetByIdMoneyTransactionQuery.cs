using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Queries.GetById;

public partial class GetByIdMoneyTransactionQuery : IRequest<GetByIdMoneyTransactionResponse>
{
    public int Id { get; set; }


}