using MediatR;

namespace Application.Features.Supports.Commands.Update;

public class UpdateSupportCommand : IRequest<UpdateSupportResponse>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetSupports";
}
