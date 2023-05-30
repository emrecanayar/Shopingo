using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ProductDelivery : Entity
    {
        public Guid ProductId { get; set; }
        public Guid DeliveryId { get; set; }
        public Product Product { get; set; }
        public Delivery Delivery { get; set; }

        public ProductDelivery()
        {

        }
        public ProductDelivery(Guid id, Guid productId, Guid deliveryId)
        {
            Id = id;
            ProductId = productId;
            DeliveryId = deliveryId;
        }

    }
}
