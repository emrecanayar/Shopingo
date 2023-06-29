using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;
using webAPI.Application.Features.Users.Rules;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Users.Queries.GetByIdUser;

public class GetByIdUserQuery : IRequest<UserDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin };
    [JsonIgnore]
    public bool RequiresAuthorization { get; set; } = true;

    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public GetByIdUserQueryHandler(IUserRepository userRepository,
                                       UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

            User? user = await _userRepository.GetAsync(b => b.Id == request.Id);
            UserDto userDto = ObjectMapper.Mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}