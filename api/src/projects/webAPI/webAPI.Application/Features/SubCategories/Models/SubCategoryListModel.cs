using Core.Persistence.Paging;
using webAPI.Application.Features.SubCategories.Dtos;

namespace webAPI.Application.Features.SubCategories.Models
{
    public class SubCategoryListModel : BasePageableModel
    {
        public IList<SubCategoryListDto> Items { get; set; }
    }
}
