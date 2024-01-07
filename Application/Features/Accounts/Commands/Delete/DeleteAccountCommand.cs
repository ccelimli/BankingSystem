using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Accounts.Commands.Delete;

public  class DeleteAccountCommand : IRequest<DeleteAccountResponse> , ICacheRemoverRequest
{
    public int Id { get; set; }

    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey =>"GetAccounts";
}
