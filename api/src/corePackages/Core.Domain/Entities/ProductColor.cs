using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ProductColor : Entity
    {
        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }

        public ProductColor()
        {

        }

        public ProductColor(Guid id, Guid productId, Guid colorId)
        {
            Id = id;
            ProductId = productId;
            ColorId = colorId;
        }
    }
}
