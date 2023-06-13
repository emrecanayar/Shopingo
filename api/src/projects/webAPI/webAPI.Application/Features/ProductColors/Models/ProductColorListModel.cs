using Core.Persistence.Paging;
using webAPI.Application.Features.ProductColors.Dtos;

namespace webAPI.Application.Features.ProductColors.Models
{
    public class ProductColorListModel : BasePageableModel
    {
        IList<ProductColorListDto> Items { get; set; }
    }
}
