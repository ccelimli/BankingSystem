namespace Application.Features.Accounts.Commands.Update;

public class UpdateAccountResponse
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public double Balance { get; set; }
    public string IBAN { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}