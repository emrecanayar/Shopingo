using Core.Persistence.Paging;
using webAPI.Application.Features.Countries.Dtos;

namespace webAPI.Application.Features.Countries.Models
{
    public class CountryListModel : BasePageableModel
    {
        public IList<CountryListDto> Items { get; set; }
    }
}
