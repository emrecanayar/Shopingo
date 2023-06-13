using Core.Persistence.Paging;
using webAPI.Application.Features.Products.Dtos;

namespace webAPI.Application.Features.ProductSizes.Models
{
    public class ProductSizeListModel : BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
