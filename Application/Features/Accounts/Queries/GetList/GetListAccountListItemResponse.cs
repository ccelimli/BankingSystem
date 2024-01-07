namespace Application.Features.Accounts.Queries.GetList;

public class GetListAccountListItemResponse
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public string IBAN { get; set; }
    public double Balance { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public DateTime CreatedDate { get; set; }
}
