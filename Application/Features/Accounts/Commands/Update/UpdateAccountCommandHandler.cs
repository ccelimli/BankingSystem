using Application.Features.Accounts.Rules;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Commands.Update;


public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly AccountBusinessRules _accountBusinessRules;
    private readonly IUserService _userService;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, AccountBusinessRules accountBusinessRules, IUserService userService)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _accountBusinessRules = accountBusinessRules;
        _userService = userService;
    }

    public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountBusinessRules.AccountMustBePresent(request.Id);
        await _userService.CheckUserExistById(request.UserId);

        Account? account = await _accountRepository.GetAsync(predicate: account => account.Id == request.Id, cancellationToken: cancellationToken);
        account = _mapper.Map(request, account);
        await _accountRepository.UpdateAsync(account);
        Account accountResponse = await _accountRepository.GetAsync(predicate: a => a.Id == account.Id, cancellationToken: cancellationToken, include: a => a.Include(a => a.User));
        UpdateAccountResponse response = _mapper.Map<UpdateAccountResponse>(accountResponse);

        return response;
    }
}
