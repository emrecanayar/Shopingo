using AutoMapper;
using Core.Domain.Entities;
using MediatR;
using webAPI.Application.Features.UserOperationClaims.Dtos;
using webAPI.Application.Features.UserOperationClaims.Rules;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public class
        CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,
            CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                      UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request,
                                                               CancellationToken cancellationToken)
        {
            UserOperationClaim mappedUserOperationClaim = ObjectMapper.Mapper.Map<UserOperationClaim>(request);
            UserOperationClaim createdUserOperationClaim =
                await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
            CreatedUserOperationClaimDto createdUserOperationClaimDto =
                ObjectMapper.Mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return createdUserOperationClaimDto;
        }
    }
}