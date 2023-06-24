using Core.Domain.Entities.Base;

namespace webAPI.Application.Features.CompanyAddresss.Dtos
{
    public class CompanyAddressDeleteDto : IEntityModel
    {
        public Guid Id { get; set; }
    }
}
