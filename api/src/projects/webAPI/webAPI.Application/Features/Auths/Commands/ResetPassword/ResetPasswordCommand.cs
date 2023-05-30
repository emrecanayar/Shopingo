using Core.Application.ResponseTypes.Concrete;
using MediatR;
using webAPI.Application.Services.AuthService;
using System.Net;

namespace webAPI.Application.Features.Auths.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<CustomResponseDto<bool>>
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

        public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, CustomResponseDto<bool>>
        {
            private readonly IAuthService _authService;

            public ResetPasswordCommandHandler(IAuthService authService)
            {
                this._authService = authService;
            }

            public async Task<CustomResponseDto<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {
                await _authService.ResetPassword(request.Token, request.Password);
                return CustomResponseDto<bool>.Success((int)HttpStatusCode.OK, true, true);
            }
        }
    }
}
