using Application.Features.Accounts.Commands.Delete;
using Application.Features.Accounts.Rules;
using Application.Features.Loans.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Loans.Commands.Delete;

public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, DeleteLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;
    private readonly LoanBusinessRules _loanBusinessRules;

    public DeleteLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper, LoanBusinessRules loanBusinessRules)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
        _loanBusinessRules = loanBusinessRules;
    }

    public async Task<DeleteLoanResponse> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        await _loanBusinessRules.LoanMustBePresent(request.Id);

        Loan? loan = await _loanRepository.GetAsync(predicate: account => account.Id == request.Id, cancellationToken: cancellationToken);
        await _loanRepository.DeleteAsync(loan);
        DeleteLoanResponse response = _mapper.Map<DeleteLoanResponse>(loan);

        return response;
    }
}