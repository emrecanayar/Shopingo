using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using webAPI.Application.Features.Users.Dtos;
using webAPI.Application.Features.Users.Rules;
using webAPI.Application.Services.UserService;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Users.Queries.GetByIdUserInformation
{
    public class GetByIdUserInformationQuery : IRequest<CustomResponseDto<UserInformationDto>>, ISecuredRequest
    {
        public Guid UserId { get; set; }
        public string[] Roles => new[] { Admin };
        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class GetByIdUserInformationQueryHandler : IRequestHandler<GetByIdUserInformationQuery, CustomResponseDto<UserInformationDto>>
        {
            private readonly IUserService _userService;
            private readonly UserBusinessRules _userBusinessRules;

            public GetByIdUserInformationQueryHandler(IUserService userService, UserBusinessRules userBusinessRules)
            {
                _userService = userService;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CustomResponseDto<UserInformationDto>> Handle(GetByIdUserInformationQuery request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistWhenSelected(request.UserId);

                User? user = await _userService.GetUserInformation(request.UserId);
                UserInformationDto userInformationDto = ObjectMapper.Mapper.Map<UserInformationDto>(user);
                return CustomResponseDto<UserInformationDto>.Success((int)HttpStatusCode.OK, userInformationDto, true);
            }
        }
    }
}