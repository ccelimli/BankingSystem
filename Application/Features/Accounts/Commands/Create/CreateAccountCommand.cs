using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Enums;
using MediatR;

namespace Application.Features.Accounts.Commands.Create;

public partial class CreateAccountCommand : IRequest<CreateAccountResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public int AccountType { get; set; }
    public int UserId { get; set; }

    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetAccounts";
}
