using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using MediatR;
using System.Text.Json.Serialization;
using webAPI.Application.Features.Users.Rules;
using webAPI.Application.Services.AuthService;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Users.Commands.UpdateUserFromAuth;

public class UpdateUserFromAuthCommand : IRequest<UpdatedUserFromAuthDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string RegistrationNumber { get; set; }
    public string Password { get; set; }
    public string? NewPassword { get; set; }
    public string[] Roles => new[] { Admin };
    [JsonIgnore]
    public bool RequiresAuthorization { get; set; } = true;
    public class UpdateUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserFromAuthCommandHandler(IUserRepository userRepository,
                                                UserBusinessRules userBusinessRules, IAuthService authService)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _authService = authService;
        }

        public async Task<UpdatedUserFromAuthDto> Handle(UpdateUserFromAuthCommand request,
                                                         CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == request.Id);
            await _userBusinessRules.UserShouldBeExist(user);
            await _userBusinessRules.UserPasswordShouldBeMatch(user, request.Password);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            if (request.NewPassword is not null && !string.IsNullOrWhiteSpace(request.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            User updatedUser = await _userRepository.UpdateAsync(user);
            UpdatedUserFromAuthDto updatedUserFromAuthDto = ObjectMapper.Mapper.Map<UpdatedUserFromAuthDto>(updatedUser);
            updatedUserFromAuthDto.AccessToken = await _authService.CreateAccessToken(user);
            return updatedUserFromAuthDto;
        }
    }
}