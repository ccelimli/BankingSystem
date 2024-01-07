using Application.Features.Accounts.Helpers;
using Application.Features.Accounts.Queries.GetList;
using Application.Features.Accounts.Rules;
using Application.Features.Users.Queries.GetList;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Commands.Create;


public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, AccountBusinessRules accountBusinessRules, IUserService userService)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _userService.CheckUserExistById(request.UserId);
        
        Account account = _mapper.Map<Account>(request);
        account.AccountNumber =Generators.AccountNumberGenerator();
        account.IBAN = Generators.IbanGenerator();
        await _accountRepository.AddAsync(account);

        Account accountResponse = await _accountRepository.GetAsync(predicate: a => a.Id == account.Id, cancellationToken: cancellationToken, include: a => a.Include(a => a.User));

        CreateAccountResponse response = _mapper.Map<CreateAccountResponse>(accountResponse);

        return response;
    }
}

