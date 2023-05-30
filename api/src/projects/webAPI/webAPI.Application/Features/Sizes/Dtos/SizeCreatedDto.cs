using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.Sizes.Dtos
{
    public class SizeCreatedDto
    {
        public Guid Id { get; set; }
        public string SizeName { get; set; }

        public CustomResponseDto<SizeCreatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<SizeCreatedDto>
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
