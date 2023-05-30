using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.ContactInfos.Dtos
{
    public class ContactInfoDeleteDto : IEntityModel
    {
        public Guid Id { get; set; }
    }
}
