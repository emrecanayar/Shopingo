using Core.Domain.Entities;
using MediatR;
using webAPI.Application.Features.UserOperationClaims.Dtos;
using webAPI.Application.Features.UserOperationClaims.Rules;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public class
        UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,
            UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                      UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request,
                                                               CancellationToken cancellationToken)
        {
            UserOperationClaim mappedUserOperationClaim = ObjectMapper.Mapper.Map<UserOperationClaim>(request);
            UserOperationClaim updatedUserOperationClaim =
                await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto =
                ObjectMapper.Mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
            return updatedUserOperationClaimDto;
        }
    }
}