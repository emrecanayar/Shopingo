using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.Sizes.Dtos
{
    public class SizeUpdateDto : IEntityModel
    {
        public Guid Id { get; set; }
        public string SizeName { get; set; }


    }
}