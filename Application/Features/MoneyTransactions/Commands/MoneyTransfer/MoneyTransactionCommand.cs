using Application.Features.MoneyTransactions.Rules;
using Application.Services.AccountService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.MoneyTransactions.Commands.MoneyTransfer;

public class MoneyTransactionCommand : IRequest<MoneyTransactionResponse> , ICacheRemoverRequest, ITransactionalRequest, ILoggableRequest
{
    public string? AccountNumber { get; set; }
    public string? IBAN { get; set; }
    public string? TargetAccountNumber { get; set; }
    public string? TargetIBAN { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }
    public DateTime TransactionDate { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetMoneyTransactions";
}
