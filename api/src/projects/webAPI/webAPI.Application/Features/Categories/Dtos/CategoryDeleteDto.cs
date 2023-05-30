using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class CategoryDeleteDto : IEntityModel
    {
        public Guid Id { get; set; }
    }
}
