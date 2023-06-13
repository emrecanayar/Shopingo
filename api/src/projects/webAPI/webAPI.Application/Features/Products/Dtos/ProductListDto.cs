using webAPI.Application.Features.ProductColors.Dtos;
using webAPI.Application.Features.ProductDeliveries.Dtos;
using webAPI.Application.Features.ProductSizes.Dtos;
using webAPI.Application.Features.ProductUploadedFiles.Dtos;

namespace webAPI.Application.Features.Products.Dtos
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductNameKey { get; set; }
        public string Description { get; set; }
        public string DescriptionKey { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedUnitPrice { get; set; }
        public int Rating { get; set; }
        public List<ProductSizeDto> ProductSizes { get; set; }
        public List<ProductColorDto> ProductColors { get; set; }
        public List<ProductDeliveryDto> ProductDeliveries { get; set; }
        public List<ProductUploadedFileDto> ProductUploadedFiles { get; set; }
    }
}
