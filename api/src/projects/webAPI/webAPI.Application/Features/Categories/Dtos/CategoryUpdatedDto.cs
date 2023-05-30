using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities.Base;
using System.Net;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class CategoryUpdatedDto : IEntityModel
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
