using Core.Persistence.Paging;
using webAPI.Application.Features.Products.Dtos;

namespace webAPI.Application.Features.Products.Models
{
    public class ProductListModel : BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
