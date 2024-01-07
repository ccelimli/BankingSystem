using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Supports.Commands.Create;

public class CreateSupportCommand : IRequest<CreateSupportResponse>, ICacheRemoverRequest, ITransactionalRequest, ILoggableRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetSupports";
}
