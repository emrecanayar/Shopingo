using webAPI.Application.Features.OperationClaims.Dtos;

namespace webAPI.Application.Features.UserOperationClaims.Dtos;

public class UserOperationClaimListDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public OperationClaimDto OperationClaim { get; set; }
}