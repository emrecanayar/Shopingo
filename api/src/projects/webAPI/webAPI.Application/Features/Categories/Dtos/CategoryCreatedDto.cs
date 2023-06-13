using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class CategoryCreatedDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Key { get; set; }

        public CustomResponseDto<CategoryCreatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<CategoryCreatedDto>()
            {
                Data = new()
                {
                    Id = Id,
                    CategoryName = CategoryName,
                    Key = Key
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
