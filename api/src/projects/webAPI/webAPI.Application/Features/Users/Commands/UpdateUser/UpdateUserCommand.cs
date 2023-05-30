using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using MediatR;
using webAPI.Application.Features.Users.Rules;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UpdatedUserDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string RegistrationNumber { get; set; }
    public string Password { get; set; }
    public string[] Roles => new[] { Admin };

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserCommandHandler(IUserRepository userRepository,
                                        UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User mappedUser = ObjectMapper.Mapper.Map<User>(request);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            User updatedUser = await _userRepository.UpdateAsync(mappedUser);
            UpdatedUserDto updatedUserDto = ObjectMapper.Mapper.Map<UpdatedUserDto>(updatedUser);
            return updatedUserDto;
        }
    }
}