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

namespace webAPI.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<CustomResponseDto<DeletedOperationClaimDto>>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string[] Roles => new[] { Admin };
        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class DeleteOperationClaimCommandHanlder : IRequestHandler<DeleteOperationClaimCommand, CustomResponseDto<DeletedOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public DeleteOperationClaimCommandHanlder(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CustomResponseDto<DeletedOperationClaimDto>> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);
                OperationClaim mappedOperationClaim = ObjectMapper.Mapper.Map<OperationClaim>(request);
                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(mappedOperationClaim);
                DeletedOperationClaimDto deletedOperationClaimDto =
                    ObjectMapper.Mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);

                return CustomResponseDto<DeletedOperationClaimDto>.Success((int)HttpStatusCode.OK, deletedOperationClaimDto, isSuccess: true);
            }
        }
    }
}