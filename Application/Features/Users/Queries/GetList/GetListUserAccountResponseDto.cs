﻿namespace Application.Features.Users.Queries.GetList;

public class GetListUserAccountResponseDto
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string IBAN { get; set; }
    public string AccountType { get; set; }
    public string Password { set; get; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}