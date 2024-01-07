using Application.Features.MoneyTransactions.Commands.WithdrawMoney;
using Application.Features.MoneyTransactions.Commands.DepositMoney;
using Application.Features.MoneyTransactions.Commands.MoneyTransfer;
using AutoMapper;
using Domain.Entities;
using Application.Features.MoneyTransactions.Commands.LoanDeptPayment;

namespace Application.Features.MoneyTransactions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MoneyTransaction, DepositMoneyTransactionCommand>().ReverseMap();
        CreateMap<MoneyTransaction, DepositMoneyTransactionResponse>()
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()))
            .ReverseMap();

        CreateMap<MoneyTransaction, WithdrawMoneyTransactionCommand>().ReverseMap();
        CreateMap<MoneyTransaction, WithdrawMoneyTransactionResponse>()
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()))
            .ReverseMap();

        CreateMap<MoneyTransaction, MoneyTransactionCommand>().ReverseMap();
        CreateMap<MoneyTransaction, MoneyTransactionResponse>()
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()))
            .ReverseMap();

        CreateMap<Loan, LoanDeptPaymentCommand>()
            .ReverseMap();
        CreateMap<Loan, LoanDeptPaymentResponse>()
            .ForMember(dest => dest.LoanType, opt => opt.MapFrom(src => src.LoanType.ToString()))
            .ReverseMap();
    }
}
