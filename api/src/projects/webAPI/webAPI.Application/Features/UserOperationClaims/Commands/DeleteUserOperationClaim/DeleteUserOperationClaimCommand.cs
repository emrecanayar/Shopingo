using AutoMapper;
using Core.Domain.Entities;
using MediatR;
using webAPI.Application.Features.UserOperationClaims.Dtos;
using webAPI.Application.Features.UserOperationClaims.Rules;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
{
    public Guid Id { get; set; }

    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
            DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                      IMapper mapper,
                                                      UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
                                                               CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim deletedUserOperationClaim =
                await _userOperationClaimRepository.DeleteAsync(mappedUserOperationClaim);
            DeletedUserOperationClaimDto deletedUserOperationClaimDto =
                _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
            return deletedUserOperationClaimDto;
        }
    }
}