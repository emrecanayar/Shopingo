using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using webAPI.Application.Features.OperationClaims.Models;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<CustomResponseDto<OperationClaimListModel>>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin };
        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, CustomResponseDto<OperationClaimListModel>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<CustomResponseDto<OperationClaimListModel>> Handle(GetListOperationClaimQuery request,
                                                              CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                                                                index: request.PageRequest.Page,
                                                                size: request.PageRequest.PageSize);
                OperationClaimListModel mappedOperationClaimListModel =
                    ObjectMapper.Mapper.Map<OperationClaimListModel>(operationClaims);

                return CustomResponseDto<OperationClaimListModel>.Success((int)HttpStatusCode.OK, mappedOperationClaimListModel, isSuccess: true);

            }
        }
    }
}
