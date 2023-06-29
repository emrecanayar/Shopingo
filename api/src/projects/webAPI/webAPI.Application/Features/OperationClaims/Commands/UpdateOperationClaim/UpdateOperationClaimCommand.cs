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

namespace webAPI.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<CustomResponseDto<UpdatedOperationClaimDto>>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] Roles => new[] { Admin };
        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, CustomResponseDto<UpdatedOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CustomResponseDto<UpdatedOperationClaimDto>> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = ObjectMapper.Mapper.Map<OperationClaim>(request);
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdatedOperationClaimDto updatedOperationClaimDto = ObjectMapper.Mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

                return CustomResponseDto<UpdatedOperationClaimDto>.Success((int)HttpStatusCode.OK, updatedOperationClaimDto, isSuccess: true);
            }
        }
    }
}