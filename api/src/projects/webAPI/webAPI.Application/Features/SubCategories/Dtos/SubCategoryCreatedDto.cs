using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.SubCategories.Dtos
{
    public class SubCategoryCreatedDto
    {
        public Guid Id { get; set; }
        public string SubCategoryName { get; set; }
        public string Key { get; set; }
        public Guid CategoryId { get; set; }

        public CustomResponseDto<SubCategoryCreatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<SubCategoryCreatedDto>()
            {
                Data = new()
                {
                    Id = Id,
                    SubCategoryName = SubCategoryName,
                    Key = Key,
                    CategoryId = CategoryId
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
