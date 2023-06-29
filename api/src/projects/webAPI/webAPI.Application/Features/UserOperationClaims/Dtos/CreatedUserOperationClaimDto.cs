namespace webAPI.Application.Features.UserOperationClaims.Dtos;

public class CreatedUserOperationClaimDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}