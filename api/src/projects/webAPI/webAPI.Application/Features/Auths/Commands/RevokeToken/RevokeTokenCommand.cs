using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Services.AuthService;
using System.Net;

namespace webAPI.Application.Features.Auths.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<CustomResponseDto<RevokedTokenDto>>
    {
        public string Token { get; set; }
        public string IPAddress { get; set; }

        public class RevokeTokenCommandHanlder : IRequestHandler<RevokeTokenCommand, CustomResponseDto<RevokedTokenDto>>
        {
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public RevokeTokenCommandHanlder(IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<CustomResponseDto<RevokedTokenDto>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
            {
                RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.Token);
                await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
                await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

                await _authService.RevokeRefreshToken(refreshToken, request.IPAddress, "Revoked without replacement");
                RevokedTokenDto revokedTokenDto = ObjectMapper.Mapper.Map<RevokedTokenDto>(refreshToken);

                return CustomResponseDto<RevokedTokenDto>.Success((int)HttpStatusCode.OK, revokedTokenDto, isSuccess: true);

            }
        }
    }
}
