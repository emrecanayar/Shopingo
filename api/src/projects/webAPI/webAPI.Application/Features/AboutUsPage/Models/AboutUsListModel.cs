using Core.Persistence.Paging;
using webAPI.Application.Features.AboutUsPage.Dtos;

namespace webAPI.Application.Features.AboutUsPage.Models
{
    public class AboutUsListModel : BasePageableModel
    {
        public IList<AboutUsListDto> Items { get; set; }
    }
}
