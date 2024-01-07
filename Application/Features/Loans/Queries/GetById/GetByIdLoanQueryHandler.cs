using Application.Features.Loans.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Loans.Queries.GetById;

public class GetByIdLoanQueryHandler : IRequestHandler<GetByIdLoanQuery, GetByIdLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;
    private readonly LoanBusinessRules _loanBusinessRules;

    public GetByIdLoanQueryHandler(ILoanRepository loanRepository, IMapper mapper, LoanBusinessRules loanBusinessRules)
    {
        _loanBusinessRules = loanBusinessRules;
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdLoanResponse> Handle(GetByIdLoanQuery request, CancellationToken cancellationToken)
    {
        await _loanBusinessRules.LoanMustBePresent(request.Id);

        Loan? loan = await _loanRepository.GetAsync(
                predicate: loan => loan.Id == request.Id,
                include: loan => loan.Include(loan => loan.User),
                cancellationToken: cancellationToken
            );

        GetByIdLoanResponse response = _mapper.Map<GetByIdLoanResponse>(loan);

        return response;
    }
}
