using Core.Persistence.Paging;
using webAPI.Application.Features.Products.Dtos;

namespace webAPI.Application.Features.ProductDeliveries.Models
{
    public class ProductDeliveryListModel : BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
