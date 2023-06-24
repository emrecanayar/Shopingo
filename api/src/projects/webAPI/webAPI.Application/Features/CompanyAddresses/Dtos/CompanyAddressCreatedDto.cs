using Core.Application.ResponseTypes.Concrete;
using System.Net;

namespace webAPI.Application.Features.ContactInfos.Dtos
{
    public class CompanyAddressCreatedDto
    {
        public Guid Id { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public CustomResponseDto<CompanyAddressCreatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<CompanyAddressCreatedDto>
            {
                Data = new()
                {
                    Id = Id,
                    AddressText = AddressText,
                    Phone = Phone,
                    Email = Email,
                    WorkingDay = WorkingDay,
                    Latitude = Latitude,
                    Longitude = Longitude
                },
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
