using MediatR;

namespace Application.Features.Supports.Commands.Delete;

public class DeleteSupportCommand : IRequest<DeleteSupportResponse>
{
    public int Id { get; set; }
}
