namespace webAPI.Application.Features.SubCategories.Dtos
{
    public class SubCategoryCreateDto
    {
        public string SubCategoryName { get; set; }
        public string Key { get; set; }
        public Guid CategoryId { get; set; }
    }
}
