namespace webAPI.Application.Features.SubCategories.Dtos
{
    public class SubCategoryListDto
    {
        public Guid Id { get; set; }
        public string SubCategoryName { get; set; }
        public string Key { get; set; }
        public Guid CategoryId { get; set; }
    }
}
