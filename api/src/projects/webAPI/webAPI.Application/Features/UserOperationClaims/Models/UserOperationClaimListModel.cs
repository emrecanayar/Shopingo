using Core.Persistence.Paging;
using webAPI.Application.Features.UserOperationClaims.Dtos;

namespace webAPI.Application.Features.UserOperationClaims.Models;

public class UserOperationClaimListModel : BasePageableModel
{
    public IList<UserOperationClaimListDto> Items { get; set; }
}