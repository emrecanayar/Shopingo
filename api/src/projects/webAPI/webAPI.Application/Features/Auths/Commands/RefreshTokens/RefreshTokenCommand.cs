using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Security.JWT;
using MediatR;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Services.AuthService;
using webAPI.Application.Services.UserService;
using System.Net;

namespace webAPI.Application.Features.Auths.Commands.RefreshTokens
{
    public class RefreshTokenCommand : IRequest<CustomResponseDto<RefreshedTokensDto>>
    {
        public string? RefreshToken { get; set; }
        public string? IPAddress { get; set; }

        public class RefreshTokenCommandHanlder : IRequestHandler<RefreshTokenCommand, CustomResponseDto<RefreshedTokensDto>>
        {
            private readonly IAuthService _authService;
            private readonly IUserService _userService;
            private readonly AuthBusinessRules _authBusinessRules;

            public RefreshTokenCommandHanlder(IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _userService = userService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<CustomResponseDto<RefreshedTokensDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            {
                RefreshToken refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken);
                await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

                if (refreshToken.Revoked != null)
                    await _authService.RevokeDescendantRefreshTokens(refreshToken, request.IPAddress,
                                                                     $"Attempted reuse of revoked ancestor token: {refreshToken.Token}");

                await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

                User user = await _userService.GetById(refreshToken.UserId);

                RefreshToken newRefreshToken = await _authService.RotateRefreshToken(user, refreshToken, request.IPAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);
                await _authService.DeleteOldRefreshTokens(refreshToken.UserId);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                RefreshedTokensDto refreshedTokensDto = new()
                { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };

                return CustomResponseDto<RefreshedTokensDto>.Success((int)HttpStatusCode.OK, refreshedTokensDto, isSuccess: true);
            }
        }
    }
}