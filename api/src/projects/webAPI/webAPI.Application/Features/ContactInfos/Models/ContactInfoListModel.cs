using Core.Persistence.Paging;
using webAPI.Application.Features.ContactInfos.Dtos;

namespace webAPI.Application.Features.ContactInfos.Models
{
    public class ContactInfoListModel : BasePageableModel
    {
        public IList<ContactInfoListDto> Items { get; set; }
    }
}
