using Application.Features.Users.Models;
using Core.Application.Requests;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.Users.Queries.GetListUser;

public class GetListUserQuery : IRequest<UserListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
    {
        private readonly IUserRepository _userRepository;

        public GetListUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page,
                                                                       size: request.PageRequest.PageSize);
            UserListModel mappedUserListModel = ObjectMapper.Mapper.Map<UserListModel>(users);
            return mappedUserListModel;
        }
    }
}