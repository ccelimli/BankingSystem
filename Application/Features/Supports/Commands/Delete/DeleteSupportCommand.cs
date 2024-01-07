using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Supports.Commands.Delete;

public class DeleteSupportCommand : IRequest<DeleteSupportResponse> , ICacheRemoverRequest, ITransactionalRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetSupports";
}
