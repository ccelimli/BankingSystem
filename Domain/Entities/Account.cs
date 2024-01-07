using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Account : Entity<int>
{
    public string AccountNumber { get; set; }
    public AccountType AccountType { get; set; }
    public double Balance { get; set; }
    public string IBAN { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
}

