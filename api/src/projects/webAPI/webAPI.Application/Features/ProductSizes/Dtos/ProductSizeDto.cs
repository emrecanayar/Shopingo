using webAPI.Application.Features.Sizes.Dtos;

namespace webAPI.Application.Features.ProductSizes.Dtos
{
    public class ProductSizeDto
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public SizeDto Size { get; set; }
    }
}
