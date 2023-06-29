using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.OperationClaims.Constants;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(OperationClaimMessages.OperationClaimExists);
        }

        public async Task OperationClaimIdShouldExistWhenSelected(Guid id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == id);
            if (operationClaim is null) throw new BusinessException(OperationClaimMessages.OperationClaimNotExists);
        }
    }
}