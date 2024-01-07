﻿using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailCannotBeDuplicated(string email)
    {
        User? user = await _userRepository.GetAsync(predicate: user => user.Email == email);

        if (user is not null)
            throw new BusinessException(UsersMessages.EmailExists);
    }

    public async Task UserPhoneNumberCannotBeDuplicated(string phoneNumber)
    {
        User? user = await _userRepository.GetAsync(predicate: user => user.PhoneNumber == phoneNumber);

        if (user is not null)
            throw new BusinessException(UsersMessages.PhoneNumberExists);
    }

    public async Task UserNationalityNoCannotBeDuplicated(string nationalityNo)
    {
        User? user = await _userRepository.GetAsync(predicate: user => user.Email == nationalityNo);

        if (user is not null)
            throw new BusinessException(UsersMessages.NationalityNoExists);
    }

    public async Task UserMustBePresent(int id)
    {
        User? user = await _userRepository.GetAsync(predicate: user => user.Id == id);

        if (user is null)
            throw new BusinessException(UsersMessages.UserNotFound);
    }
}
