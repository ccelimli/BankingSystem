using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MoneyTransactionsRepository : EfRepositoryBase<MoneyTransaction, int, BaseDbContext>, IMoneyTransactionRepository
{
    public MoneyTransactionsRepository(BaseDbContext context) : base(context)
    {
    }
}
