using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;
using webAPI.Application.Features.Users.Rules;
using webAPI.Application.Services.Repositories;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<DeletedUserDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin };
    [JsonIgnore]
    public bool RequiresAuthorization { get; set; } = true;
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public DeleteUserCommandHandler(IUserRepository userRepository,
                                        UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

            User mappedUser = ObjectMapper.Mapper.Map<User>(request);
            User deletedUser = await _userRepository.DeleteAsync(mappedUser);
            DeletedUserDto deletedUserDto = ObjectMapper.Mapper.Map<DeletedUserDto>(deletedUser);
            return deletedUserDto;
        }
    }
}