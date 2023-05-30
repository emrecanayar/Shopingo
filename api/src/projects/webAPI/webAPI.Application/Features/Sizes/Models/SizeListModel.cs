using Core.Persistence.Paging;
using webAPI.Application.Features.Sizes.Dtos;

namespace webAPI.Application.Features.Sizes.Models
{
    public class SizeListModel : BasePageableModel
    {
        public IList<SizeListDto> Items { get; set; }
    }
}
