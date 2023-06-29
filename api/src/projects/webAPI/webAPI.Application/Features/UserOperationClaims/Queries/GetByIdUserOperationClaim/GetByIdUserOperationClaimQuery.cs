using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using webAPI.Application.Features.UserOperationClaims.Dtos;
using webAPI.Application.Features.UserOperationClaims.Rules;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class GetByIdUserOperationClaimQuery : IRequest<UserOperationClaimDto>
{
    public Guid Id { get; set; }

    public class
        GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                     UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<UserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request,
                                                        CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

            UserOperationClaim? userOperationClaim =
                await _userOperationClaimRepository.GetAsync(b => b.Id == request.Id, include: x => x.Include(x => x.OperationClaim));
            UserOperationClaimDto userOperationClaimDto = ObjectMapper.Mapper.Map<UserOperationClaimDto>(userOperationClaim);
            return userOperationClaimDto;
        }
    }
}