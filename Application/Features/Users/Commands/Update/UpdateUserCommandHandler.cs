using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Update;

public partial class UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserMustBePresent(request.Id);
            await _userBusinessRules.UserEmailCannotBeDuplicated(request.Email);
            await _userBusinessRules.UserPhoneNumberCannotBeDuplicated(request.PhoneNumber);
            await _userBusinessRules.UserNationalityNoCannotBeDuplicated(request.NationalityNo);

            User? user = await _userRepository.GetAsync(predicate: user => user.Id == request.Id, cancellationToken: cancellationToken);
            user = _mapper.Map(request, user);

            await _userRepository.UpdateAsync(user);
            UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);

            return response;
        }
    }
}
