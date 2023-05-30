using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class CategoryCreatedDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Key { get; set; }

        public CustomResponseDto<CategoryUpdatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<CategoryUpdatedDto>()
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
