using MediatR;

namespace Application.Features.Users.Commands.Delete;

public  class DeleteUserCommand : IRequest<DeleteUserResponse>
{
    public int Id { get; set; }
}
