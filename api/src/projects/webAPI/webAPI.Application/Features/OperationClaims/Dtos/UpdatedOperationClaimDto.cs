using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.OperationClaims.Dtos
{
    public class UpdatedOperationClaimDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CustomResponseDto<UpdatedOperationClaimDto> CreateResponseDto()
        {
            return new CustomResponseDto<UpdatedOperationClaimDto>()
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
