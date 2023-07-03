using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using MediatR;
using System.Text.Json.Serialization;
using webAPI.Application.Features.Users.Rules;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>, ISecuredRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string RegistrationNumber { get; set; }
    public string Password { get; set; }
    public int CountryId { get; set; }
    public string[] Roles => new[] { Admin };
    [JsonIgnore]
    public bool RequiresAuthorization { get; set; } = true;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository,
                                        UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User mappedUser = ObjectMapper.Mapper.Map<User>(request);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            User createdUser = await _userRepository.AddAsync(mappedUser);
            CreatedUserDto createdUserDto = ObjectMapper.Mapper.Map<CreatedUserDto>(createdUser);
            return createdUserDto;
        }
    }
}