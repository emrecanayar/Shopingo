using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ProductSize : Entity
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }

        public ProductSize()
        {

        }

        public ProductSize(Guid id, Guid productId, Guid sizeId)
        {
            Id = id;
            ProductId = productId;
            SizeId = sizeId;
        }
    }
}
