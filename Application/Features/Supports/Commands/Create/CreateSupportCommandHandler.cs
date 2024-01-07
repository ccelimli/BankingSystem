﻿using Application.Features.Supports.Rules;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Supports.Commands.Create;

public class CreateSupportCommandHandler : IRequestHandler<CreateSupportCommand, CreateSupportResponse>
{
    private readonly ISupportRepository _supportRepository;
    private readonly IMapper _mapper;
    private readonly SupportBusinessRules _supportBusinessRules;
    private readonly IUserService _userService;

    public CreateSupportCommandHandler(ISupportRepository supportRepository, IMapper mapper, SupportBusinessRules supportBusinessRules, IUserService userService)
    {
        _supportRepository = supportRepository;
        _mapper = mapper;
        _supportBusinessRules = supportBusinessRules;
        _userService = userService;
    }

    public async Task<CreateSupportResponse> Handle(CreateSupportCommand request, CancellationToken cancellationToken)
    {
        await _userService.CheckUserExistById(request.UserId);

        await _supportBusinessRules.SupportTitleCannotBeDuplicated(request.Title);

        Support support = _mapper.Map<Support>(request);
        await _supportRepository.AddAsync(support);
        CreateSupportResponse response = _mapper.Map<CreateSupportResponse>(support);

        return response;
    }
}

