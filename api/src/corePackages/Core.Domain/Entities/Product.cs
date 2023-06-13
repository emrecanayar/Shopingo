using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public string ProductNameKey { get; set; }
        public string Description { get; set; }
        public string DescriptionKey { get; set; }
        public string ProductCode { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedUnitPrice { get; set; }
        public int Rating { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductDelivery> ProductDeliveries { get; set; }
        public ICollection<ProductUploadedFile> ProductUploadedFiles { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public Product()
        {
            ProductSizes = new HashSet<ProductSize>();
            ProductColors = new HashSet<ProductColor>();
            ProductDeliveries = new HashSet<ProductDelivery>();
            ProductUploadedFiles = new HashSet<ProductUploadedFile>();
            ProductCategories = new HashSet<ProductCategory>();

        }

        public Product(Guid id, string productName, string productNameKey, string description, string descriptionKey, string productCode, int stockQuantity, decimal unitPrice, decimal discountedUnitPrice, int rating)
        {
            Id = id;
            ProductName = productName;
            ProductNameKey = productNameKey;
            Description = description;
            DescriptionKey = descriptionKey;
            ProductCode = productCode;
            StockQuantity = stockQuantity;
            UnitPrice = unitPrice;
            DiscountedUnitPrice = discountedUnitPrice;
            Rating = rating;
        }
    }
}
