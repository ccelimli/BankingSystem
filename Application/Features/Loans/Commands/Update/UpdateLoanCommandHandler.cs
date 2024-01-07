using Application.Features.Accounts.Commands.Update;
using Application.Features.Accounts.Rules;
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

namespace Application.Features.Loans.Commands.Update;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, UpdateLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public UpdateLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<UpdateLoanResponse> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        Loan? Loan = await _loanRepository.GetAsync(predicate: account => account.Id == request.Id, cancellationToken: cancellationToken);
        Loan = _mapper.Map(request, Loan);

        await _loanRepository.UpdateAsync(Loan);
        Loan loanResponse = await _loanRepository.GetAsync(predicate: a => a.Id == Loan.Id, cancellationToken: cancellationToken, include: a => a.Include(a => a.User));
        UpdateLoanResponse response = _mapper.Map<UpdateLoanResponse>(loanResponse);

        return response;
    }
}