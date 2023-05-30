using Application.Features.Users.Models;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using webAPI.Application.Services.Repositories;
using System.Net;

namespace webAPI.Application.Features.Users.Queries.GetListUserByDynamic
{
    public class GetListUserByDynamicQuery : IRequest<CustomResponseDto<UserListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListUserByDynamicQueryHandler : IRequestHandler<GetListUserByDynamicQuery, CustomResponseDto<UserListModel>>
        {
            private readonly IUserRepository _userRepository;

            public GetListUserByDynamicQueryHandler(IUserRepository userRepository)
            {
                this._userRepository = userRepository;
            }

            public async Task<CustomResponseDto<UserListModel>> Handle(GetListUserByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListByDynamicAsync(index: request.PageRequest.Page,
                                                                                    size: request.PageRequest.PageSize, dynamic: request.Dynamic);
                UserListModel mappedUserListModel = ObjectMapper.Mapper.Map<UserListModel>(users);
                return CustomResponseDto<UserListModel>.Success((int)HttpStatusCode.OK, mappedUserListModel, true);
            }
        }
    }
}
