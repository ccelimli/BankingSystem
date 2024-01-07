using Application.Features.Accounts.Queries.GetList;
using Application.Features.Credit.Commands.Create;
using Application.Features.Loans.Commands.Create;
using Application.Features.Loans.Commands.Delete;
using Application.Features.Loans.Commands.Update;
using Application.Features.Loans.Queries.GetById;
using Application.Features.Loans.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Loan, CreateLoanCommand>()
            .ForMember(dest => dest.LoanType, opt => opt.MapFrom(src => (int)src.LoanType))
            .ReverseMap();

        CreateMap<Loan, CreateLoanResponse>()
            .ForMember(dest => dest.LoanType, opt => opt.MapFrom(src => src.LoanType.ToString()))
            .ForMember(dest => dest.LoanStatus, opt => opt.MapFrom(src => src.LoanStatus.ToString()))
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName.ToString()))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName.ToString()))
            .ReverseMap();

        CreateMap<Loan, UpdateLoanCommand>()
            .ForMember(dest => dest.LoanStatus, opt => opt.MapFrom(src => (int)src.LoanStatus))
            .ReverseMap();
        CreateMap<Loan, UpdateLoanResponse>()
            .ForMember(dest => dest.LoanType, opt => opt.MapFrom(src => src.LoanType.ToString()))
            .ForMember(dest => dest.LoanStatus, opt => opt.MapFrom(src => src.LoanStatus.ToString()))
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName.ToString()))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName.ToString()))
            .ReverseMap();

        CreateMap<Loan, DeleteLoanCommand>().ReverseMap();
        CreateMap<Loan, DeleteLoanResponse>().ReverseMap();

        CreateMap<Loan, GetListLoanListResponse>()
            .ForMember(dest => dest.LoanType, opt => opt.MapFrom(src => src.LoanType.ToString()))
            .ForMember(dest => dest.LoanStatus, opt => opt.MapFrom(src => src.LoanStatus.ToString()))
           .ReverseMap();
        CreateMap<Loan, GetByIdLoanResponse>()
            .ForMember(dest => dest.LoanType, opt => opt.MapFrom(src => src.LoanType.ToString()))
            .ForMember(dest => dest.LoanStatus, opt => opt.MapFrom(src => src.LoanStatus.ToString()))
          .ReverseMap();
        CreateMap<Paginate<Loan>, GetListResponse<GetListLoanListResponse>>().ReverseMap();
    }
}
