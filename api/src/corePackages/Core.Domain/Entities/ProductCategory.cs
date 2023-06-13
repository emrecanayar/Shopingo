using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ProductCategory : Entity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public ProductCategory()
        {

        }

        public ProductCategory(Guid productId, Guid categoryId, Guid? subCategoryId) : this()
        {
            ProductId = productId;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
        }
    }
}
