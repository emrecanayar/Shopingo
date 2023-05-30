using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Color : Entity
    {
        public string ColorName { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }

        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        public Color(Guid id, string colorName)
        {
            Id = id;
            ColorName = colorName;
        }
    }
}
