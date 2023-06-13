using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.ContactUsForms.Dtos
{
    public class ContactUsFormDeleteDto : IEntityModel
    {
        public Guid Id { get; set; }
    }
}
