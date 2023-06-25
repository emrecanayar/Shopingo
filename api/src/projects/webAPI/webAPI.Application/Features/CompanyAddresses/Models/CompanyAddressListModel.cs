using Core.Persistence.Paging;
using webAPI.Application.Features.CompanyAddresss.Dtos;

namespace webAPI.Application.Features.CompanyAddresses.Models
{
    public class CompanyAddressListModel : BasePageableModel
    {
        public IList<CompanyAddressListDto> Items { get; set; }
    }
}
