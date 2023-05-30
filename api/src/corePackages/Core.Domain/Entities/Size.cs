using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Size : Entity
    {
        public string SizeName { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public Size(Guid id, string sizeName)
        {
            Id = id;
            SizeName = sizeName;
        }
    }
}
