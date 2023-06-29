using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;
using System.Net;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Services.AuthService;
using webAPI.Application.Services.Repositories;
using static Core.Domain.ComplexTypes.Enums;

namespace webAPI.Application.Features.Auths.Commands.Register
{
    public class RegisterCommand : IRequest<CustomResponseDto<RegisteredDto>>
    {
        public UserForRegisterDto UserForRegister { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, CustomResponseDto<RegisteredDto>>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<CustomResponseDto<RegisteredDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailCantNotBeDuplicatedWhenRegistered(request.UserForRegister.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegister.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    Email = request.UserForRegister.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegister.FirstName,
                    LastName = request.UserForRegister.LastName,
                    Status = RecordStatu.Active,
                    AuthenticatorType = AuthenticatorType.None,
                    CultureType = CultureType.US,
                    RegistrationNumber = request.UserForRegister.RegistrationNumber,
                    UserName = request.UserForRegister.UserName
                };

                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };

                return CustomResponseDto<RegisteredDto>.Success((int)HttpStatusCode.OK, registeredDto, isSuccess: true);
            }
        }
    }
}