using MediatR;

namespace Application.Features.Accounts.Commands.Update;

public partial class UpdateAccountCommand : IRequest<UpdateAccountResponse>
{
    public int Id { get; set; }
    public int AccountType { get; set; }
    public double Balance { get; set; }
    public int UserId { get; set; }
}
