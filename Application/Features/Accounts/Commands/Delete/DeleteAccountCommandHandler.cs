﻿using Application.Features.Accounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Accounts.Commands.Delete;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly AccountBusinessRules _accountBusinessRules;

    public DeleteAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, AccountBusinessRules accountBusinessRules)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _accountBusinessRules = accountBusinessRules;
    }

    public async Task<DeleteAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountBusinessRules.AccountMustBePresent(request.Id);

        Account? account = await _accountRepository.GetAsync(predicate: account => account.Id == request.Id, cancellationToken: cancellationToken);
        await _accountRepository.DeleteAsync(account);
        DeleteAccountResponse response = _mapper.Map<DeleteAccountResponse>(account);

        return response;
    }
}
