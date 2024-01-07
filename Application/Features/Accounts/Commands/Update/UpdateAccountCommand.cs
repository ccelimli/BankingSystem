using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Accounts.Commands.Update;

public partial class UpdateAccountCommand : IRequest<UpdateAccountResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public int AccountType { get; set; }
    public double Balance { get; set; }
    public int UserId { get; set; }

    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetAccounts";
}
