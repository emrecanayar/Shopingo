using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.Sizes.Dtos
{
    public class SizeDeleteDto : IEntityModel
    {
        public Guid Id { get; set; }
    }
}
