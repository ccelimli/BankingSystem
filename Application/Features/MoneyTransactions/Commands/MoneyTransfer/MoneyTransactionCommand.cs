using Application.Features.MoneyTransactions.Rules;
using Application.Services.AccountService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.MoneyTransactions.Commands.MoneyTransfer;

public class MoneyTransactionCommand : IRequest<MoneyTransactionResponse>
{
    public string? AccountNumber { get; set; }
    public string? IBAN { get; set; }
    public string? TargetAccountNumber { get; set; }
    public string? TargetIBAN { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }
    public DateTime TransactionDate { get; set; }


}
