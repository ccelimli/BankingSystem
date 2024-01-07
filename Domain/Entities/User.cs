using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class User : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string NationalityNo { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int FindexScore { get; set; }
    public UserType UserType { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool? Status { get; set; }
    public string? Role { get; set; }

    public virtual ICollection<Account> Accounts { get; set; }  
}
