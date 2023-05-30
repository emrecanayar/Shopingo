using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class SubCategory : Entity
    {
        public string SubCategoryName { get; set; }
        public string Key { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public SubCategory()
        {

        }

        public SubCategory(string subCategoryName, string key, Guid categoryId)
        {
            SubCategoryName = subCategoryName;
            Key = key;
            CategoryId = categoryId;
        }
    }
}
