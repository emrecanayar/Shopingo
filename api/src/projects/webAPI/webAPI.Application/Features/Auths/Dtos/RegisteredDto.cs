using Core.Application.ResponseTypes.Concrete;
using System.Net;
using static webAPI.Application.Features.Auths.Dtos.LoggedDto;

namespace webAPI.Application.Features.Auths.Dtos
{
    public class RegisteredDto : RefreshedTokensDto
    {
        public CustomResponseDto<LoggedResponseDto> CreateResponseDto()
        {
            return new CustomResponseDto<LoggedResponseDto>()
            {
                Data = new()
                {
                    AccessToken = AccessToken
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
