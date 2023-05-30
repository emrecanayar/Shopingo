using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.SubCategories.Dtos
{
    public class SubCategoryDeleteDto : IEntityModel
    {
        public Guid Id { get; set; }
    }
}
