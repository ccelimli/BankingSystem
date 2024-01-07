using MediatR;

namespace Application.Features.Supports.Commands.Create;

public class CreateSupportCommand : IRequest<CreateSupportResponse>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
}
