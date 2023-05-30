using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Security.JWT;
using MediatR;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Features.Users.Dtos;
using webAPI.Application.Services.AuthService;
using webAPI.Application.Services.UserService;
using System.Net;
using static Core.Domain.ComplexTypes.Enums;

namespace webAPI.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<CustomResponseDto<LoggedDto>>
    {
        public UserLoginDto UserLoginDto { get; set; }
        public string IPAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, CustomResponseDto<LoggedDto>>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserService userService, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<CustomResponseDto<LoggedDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _authBusinessRules.LoginRule(request);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserLoginDto.Password);

                LoggedDto loggedDto = new();

                if (user.AuthenticatorType is not AuthenticatorType.None)
                {
                    if (request.UserLoginDto.AuthenticatorCode is null)
                    {
                        await _authService.SendAuthenticatorCode(user);
                        loggedDto.RequiredAuthenticatorType = user.AuthenticatorType;
                        return CustomResponseDto<LoggedDto>.Success((int)HttpStatusCode.OK, loggedDto, isSuccess: true);
                    }

                    await _authService.VerifyAuthenticatorCode(user, request.UserLoginDto.AuthenticatorCode);
                }

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                await _authService.DeleteOldRefreshTokens(user.Id);

                loggedDto.AccessToken = createdAccessToken;
                loggedDto.RefreshToken = addedRefreshToken;
                return CustomResponseDto<LoggedDto>.Success((int)HttpStatusCode.OK, loggedDto, isSuccess: true);
            }
        }
    }
}