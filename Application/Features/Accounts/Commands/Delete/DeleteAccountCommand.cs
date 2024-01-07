using MediatR;

namespace Application.Features.Accounts.Commands.Delete;

public  class DeleteAccountCommand : IRequest<DeleteAccountResponse>
{
    public int Id { get; set; }
}
