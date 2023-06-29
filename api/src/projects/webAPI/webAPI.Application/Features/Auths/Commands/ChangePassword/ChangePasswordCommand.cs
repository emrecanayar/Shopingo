using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Services.AuthService;
using static Core.Domain.Constants.OperationClaims;

namespace webAPI.Application.Features.Auths.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<CustomResponseDto<bool>>, ISecuredRequest
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string[] Roles => new[] { Admin };
        [JsonIgnore]
        public bool RequiresAuthorization { get; set; } = true;

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, CustomResponseDto<bool>>
        {
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public ChangePasswordCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                this._authService = authService;
                this._authBusinessRules = authBusinessRules;
            }

            public async Task<CustomResponseDto<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.IsConfirmPasswordForChangePassword(new ChangePasswordDto { Password = request.Password, NewPassword = request.NewPassword, ConfirmPassword = request.ConfirmPassword });

                await _authService.ChangePassword(request.UserId, new ChangePasswordDto { Password = request.Password, NewPassword = request.NewPassword, ConfirmPassword = request.ConfirmPassword });

                return CustomResponseDto<bool>.Success((int)HttpStatusCode.OK, true, true);
            }
        }
    }
}
