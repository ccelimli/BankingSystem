using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Supports.Queries.GetById;

public  class GetByIdSupportQuery : IRequest<GetByIdSupportResponse>, ICacheableRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string CacheKey => "";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetSupports";
}
