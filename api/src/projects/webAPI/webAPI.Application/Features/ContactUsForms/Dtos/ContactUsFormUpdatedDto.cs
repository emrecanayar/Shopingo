using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities.Base;
using System.Net;

namespace webAPI.Application.Features.ContactUsForms.Dtos
{
    public class ContactUsFormUpdatedDto : IEntityModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }

        public CustomResponseDto<ContactUsFormUpdatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<ContactUsFormUpdatedDto>()
            {
                Data = new()
                {
                    Id = Id,
                    FullName = FullName,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Message = Message,
                    UserId = UserId
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
