namespace Application.Features.Accounts.Queries.GetById;

public class GetByIdAccountResponse
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public double Balance { get; set; }
    public GetByIdAccountUserResponseDto User { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
