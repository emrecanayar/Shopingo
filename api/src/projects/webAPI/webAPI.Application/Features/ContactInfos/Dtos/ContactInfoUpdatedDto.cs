using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities.Base;
using System.Net;

namespace webAPI.Application.Features.ContactInfos.Dtos
{
    public class ContactInfoUpdatedDto : IEntityModel
    {
        public Guid Id { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }

        public CustomResponseDto<ContactInfoUpdatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<ContactInfoUpdatedDto>()
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
