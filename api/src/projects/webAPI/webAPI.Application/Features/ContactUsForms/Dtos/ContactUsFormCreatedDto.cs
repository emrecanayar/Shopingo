using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.ContactUsForms.Dtos
{
    public class ContactUsFormCreatedDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
        public CustomResponseDto<ContactUsFormCreatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<ContactUsFormCreatedDto>()
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
