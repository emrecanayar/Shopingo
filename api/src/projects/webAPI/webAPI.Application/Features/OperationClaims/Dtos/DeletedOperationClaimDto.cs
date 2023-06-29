using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.OperationClaims.Dtos
{
    public class DeletedOperationClaimDto
    {
        public Guid Id { get; set; }

        public CustomResponseDto<DeletedOperationClaimDto> CreateResponseDto()
        {
            return new CustomResponseDto<DeletedOperationClaimDto>()
            {
                Data = new()
                {
                    Id = Id
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
