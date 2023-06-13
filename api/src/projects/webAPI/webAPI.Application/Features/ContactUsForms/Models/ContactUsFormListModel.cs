using Core.Persistence.Paging;
using webAPI.Application.Features.ContactUsForms.Dtos;

namespace webAPI.Application.Features.ContactUsForms.Models
{
    public class ContactUsFormListModel : BasePageableModel
    {
        public IList<ContactUsFormListDto> Items { get; set; }
    }
}
