using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using webAPI.Application.Features.OperationClaims.Dtos;
using webAPI.Application.Features.OperationClaims.Rules;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CustomResponseDto<CreatedOperationClaimDto>>, ISecuredRequest
    {
        public string Name { get; set; }
        public string[] Roles => new[] { Admin };

        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class CreateOperationClaimCommandHandlder : IRequestHandler<CreateOperationClaimCommand, CustomResponseDto<CreatedOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandlder(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CustomResponseDto<CreatedOperationClaimDto>> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = ObjectMapper.Mapper.Map<OperationClaim>(request);
                await _operationClaimBusinessRules.OperationClaimCanNotBeDuplicatedWhenInserted(request.Name);
                OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);
                CreatedOperationClaimDto createdOperationClaimDto = ObjectMapper.Mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
                return CustomResponseDto<CreatedOperationClaimDto>.Success((int)HttpStatusCode.Created, createdOperationClaimDto, isSuccess: true);
            }
        }
    }
}