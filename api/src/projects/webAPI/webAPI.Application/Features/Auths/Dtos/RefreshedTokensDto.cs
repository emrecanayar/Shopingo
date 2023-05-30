using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Security.JWT;
using System.Net;
using static webAPI.Application.Features.Auths.Dtos.LoggedDto;

namespace webAPI.Application.Features.Auths.Dtos
{
    public class RefreshedTokensDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public CustomResponseDto<LoggedResponseDto> CreateResponseDto()
        {
            return new CustomResponseDto<LoggedResponseDto>()
            {
                Data = new()
                {
                    AccessToken = AccessToken,
                    RefreshToken = RefreshToken is not null ? new LoggedRefreshTokenDto
                    {
                        Token = RefreshToken.Token,
                        Expires = RefreshToken.Expires
                    } : null,

                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
