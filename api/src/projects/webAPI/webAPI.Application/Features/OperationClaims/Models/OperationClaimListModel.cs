using Core.Persistence.Paging;
using webAPI.Application.Features.OperationClaims.Dtos;

namespace webAPI.Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel : BasePageableModel
    {
        public IList<OperationClaimListDto> Items { get; set; }

    }
}
