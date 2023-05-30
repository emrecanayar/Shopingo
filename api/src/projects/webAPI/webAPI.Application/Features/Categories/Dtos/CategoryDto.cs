using webAPI.Application.Features.SubCategories.Dtos;

namespace webAPI.Application.Features.Categories.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Key { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}
