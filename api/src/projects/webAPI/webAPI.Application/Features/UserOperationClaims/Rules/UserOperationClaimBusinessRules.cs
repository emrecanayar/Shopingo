using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using webAPI.Application.Features.UserOperationClaims.Constants;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules : BaseBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task UserOperationClaimIdShouldExistWhenSelected(Guid id)
    {
        UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(UserOperationClaimMessages.UserOperationClaimNotExists);
    }
}