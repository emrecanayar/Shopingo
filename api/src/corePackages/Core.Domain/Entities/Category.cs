using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Category : Entity
    {
        public string CategoryName { get; set; }
        public string Key { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public Category(string categoryName, string key)
        {
            CategoryName = categoryName;
            Key = key;
        }
    }
}
