using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.OperationClaims.Dtos
{
    public class CreatedOperationClaimDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CustomResponseDto<CreatedOperationClaimDto> CreateResponseDto()
        {
            return new CustomResponseDto<CreatedOperationClaimDto>()
            {
                Data = new()
                {
                    Id = Id,
                    Name = Name
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}