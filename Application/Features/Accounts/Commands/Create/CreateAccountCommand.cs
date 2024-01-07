using Domain.Enums;
using MediatR;

namespace Application.Features.Accounts.Commands.Create;

public partial class CreateAccountCommand : IRequest<CreateAccountResponse>
{
    public int AccountType { get; set; }
    public int UserId { get; set; }
}
