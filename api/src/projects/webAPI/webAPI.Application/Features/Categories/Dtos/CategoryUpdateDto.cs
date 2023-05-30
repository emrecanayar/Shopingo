using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class CategoryUpdateDto : IEntityModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Key { get; set; }
    }
}
