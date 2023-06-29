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

namespace webAPI.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<CustomResponseDto<OperationClaimDto>>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string[] Roles => new[] { Admin };
        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, CustomResponseDto<OperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository,
                                                     OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CustomResponseDto<OperationClaimDto>> Handle(GetByIdOperationClaimQuery request,
                                                        CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(b => b.Id == request.Id);
                OperationClaimDto operationClaimDto = ObjectMapper.Mapper.Map<OperationClaimDto>(operationClaim);

                return CustomResponseDto<OperationClaimDto>.Success((int)HttpStatusCode.OK, operationClaimDto, isSuccess: true);
            }
        }
    }
}