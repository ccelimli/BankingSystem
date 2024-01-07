using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Create;

public partial class CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailCannotBeDuplicated(request.Email);
            await _userBusinessRules.UserPhoneNumberCannotBeDuplicated(request.PhoneNumber);
            await _userBusinessRules.UserNationalityNoCannotBeDuplicated(request.NationalityNo);

            User user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user);
            CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);

            return response;
        }
    }
}
