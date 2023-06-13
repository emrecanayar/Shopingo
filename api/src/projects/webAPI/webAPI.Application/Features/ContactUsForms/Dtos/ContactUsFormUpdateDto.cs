using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class ContactUsFormUpdateDto : IEntityModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
    }
}
