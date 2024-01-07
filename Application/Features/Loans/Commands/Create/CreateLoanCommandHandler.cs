using Application.Features.Credit.Commands.Create;
using Application.Features.Loans.Helpers;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Create
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, CreateLoanResponse>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper, IUserService userService)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CreateLoanResponse> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            await _userService.CheckUserExistById(request.UserId);

            Loan loan = _mapper.Map<Loan>(request);
            loan.MonthlyPaymentDate = DateTime.UtcNow;
            loan.TotalPaymentAmount= Calculators.LoanInterestRateCalculator(request.LoanType, request.RequestedLoanAmount, request.NumberOfInstallments, "TotalPaymentAmount"); 
            loan.MonthlyPaymentAmount = Calculators.LoanInterestRateCalculator(request.LoanType, request.RequestedLoanAmount, request.NumberOfInstallments, "TotalPaymentAmount"); 
            loan.InterestRate = Calculators.LoanInterestRateCalculator(request.LoanType, request.RequestedLoanAmount, request.NumberOfInstallments, "InterestRate"); 
            loan.TotalRate = Calculators.LoanInterestRateCalculator(request.LoanType, request.RequestedLoanAmount, request.NumberOfInstallments, "TotalRate");
            loan.Avail = loan.TotalPaymentAmount;
            loan.NumberOfRemainingInstallments = request.NumberOfInstallments;

            await _loanRepository.AddAsync(loan);

            Loan loanResponse = await _loanRepository.GetAsync(predicate: a => a.Id == loan.Id, cancellationToken: cancellationToken, include: a => a.Include(a => a.User));


            CreateLoanResponse response = _mapper.Map<CreateLoanResponse>(loan);

            return response;
        }
    }

}
