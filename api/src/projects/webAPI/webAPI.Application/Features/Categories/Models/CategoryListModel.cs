using Core.Persistence.Paging;
using webAPI.Application.Features.Categories.Dtos;

namespace webAPI.Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
