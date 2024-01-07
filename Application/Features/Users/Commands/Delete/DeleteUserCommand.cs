using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Users.Commands.Delete;

public  class DeleteUserCommand : IRequest<DeleteUserResponse>, ICacheRemoverRequest,ITransactionalRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetUsers";
}
