using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities.Base;
using System.Net;

namespace webAPI.Application.Features.CompanyAddresss.Dtos
{
    public class CompanyAddressUpdatedDto : IEntityModel
    {
        public Guid Id { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public CustomResponseDto<CompanyAddressUpdatedDto> CreateResponseDto()
        {
            return new CustomResponseDto<CompanyAddressUpdatedDto>()
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
