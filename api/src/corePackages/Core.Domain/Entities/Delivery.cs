using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Delivery : Entity
    {
        public string DeliveryName { get; set; }
        public ICollection<ProductDelivery> ProductDeliveries { get; set; }
        public Delivery()
        {
            ProductDeliveries = new HashSet<ProductDelivery>();
        }

        public Delivery(Guid id, string deliveryName)
        {
            Id = id;
            DeliveryName = deliveryName;
        }
    }
}
