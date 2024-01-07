using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Loans.Queries.GetList;

public class GetListLoanQueryHandler : IRequestHandler<GetListLoanQuery, GetListResponse<GetListLoanListResponse>>
{
    private readonly ILoanRepository _accountRepository;
    private readonly IMapper _mapper;

    public GetListLoanQueryHandler(ILoanRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListLoanListResponse>> Handle(GetListLoanQuery request, CancellationToken cancellationToken)
    {
        Paginate<Loan> loans = await _accountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: loan => loan.Include(loan => loan.User),
                cancellationToken: cancellationToken
            );
        GetListResponse<GetListLoanListResponse> response = _mapper.Map<GetListResponse<GetListLoanListResponse>>(loans);

        return response;
    }
}
