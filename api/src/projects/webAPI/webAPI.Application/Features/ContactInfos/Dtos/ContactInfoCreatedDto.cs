using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.ContactInfos.Dtos
{
    public class ContactInfoCreatedDto
    {
        public Guid Id { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }

        public CustomResponseDto<ContactInfoCreatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<ContactInfoCreatedDto>
            {
                Data = new()
                {
                    Id = Id,
                    AddressText = AddressText,
                    Phone = Phone,
                    Email = Email,
                    WorkingDay = WorkingDay,
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
