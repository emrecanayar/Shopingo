using Core.Application.Requests;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using webAPI.Application.Features.UserOperationClaims.Models;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;

public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
{
    public PageRequest PageRequest { get; set; }

    public class
        GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery,
            UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request,
                                                              CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                                                                    index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize,
                                                                    include: x => x.Include(x => x.OperationClaim));
            UserOperationClaimListModel mappedUserOperationClaimListModel =
                ObjectMapper.Mapper.Map<UserOperationClaimListModel>(userOperationClaims);
            return mappedUserOperationClaimListModel;
        }
    }
}