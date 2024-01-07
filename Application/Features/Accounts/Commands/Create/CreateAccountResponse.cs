namespace Application.Features.Accounts.Commands.Create;

public class CreateAccountResponse
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }
    public string IBAN{ get; set; }
    public double Balance { get; set; }
    public DateTime CreatedDate { get; set; }

}