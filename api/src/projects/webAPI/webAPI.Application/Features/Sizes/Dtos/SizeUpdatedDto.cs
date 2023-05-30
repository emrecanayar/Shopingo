using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.Sizes.Dtos
{
    public class SizeUpdatedDto
    {
        public Guid Id { get; set; }
        public string SizeName { get; set; }

        public CustomResponseDto<SizeUpdatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<SizeUpdatedDto>
            {
                Data = new()
                {
                    Id = Id,
                    SizeName = SizeName
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
