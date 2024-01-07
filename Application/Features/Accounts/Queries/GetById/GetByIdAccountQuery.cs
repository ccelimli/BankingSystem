using Application.Features.Accounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Queries.GetById;

public class GetByIdAccountQuery : IRequest<GetByIdAccountResponse>
{
    public int Id { get; set; }

    public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQuery, GetByIdAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly AccountBusinessRules _accountBusinessRules;

        public GetByIdAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper, AccountBusinessRules accountBusinessRules)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _accountBusinessRules = accountBusinessRules;
        }
        public async Task<GetByIdAccountResponse> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
        {
            await _accountBusinessRules.AccountMustBePresent(request.Id);

            Account? account = await _accountRepository.GetAsync(
                    predicate: account => account.Id == request.Id,
                    include: account => account.Include(account => account.User),
                    cancellationToken: cancellationToken
                );

            GetByIdAccountResponse response = _mapper.Map<GetByIdAccountResponse>(account);

            return response;
        }
    }
}
