using Core.Application.ResponseTypes.Concrete;
using MediatR;
using webAPI.Application.Services.AuthService;
using System.Net;

namespace webAPI.Application.Features.Auths.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<CustomResponseDto<bool>>
    {
        public string Email { get; set; }

        public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, CustomResponseDto<bool>>
        {
            private readonly IAuthService _authService;

            public ForgotPasswordCommandHandler(IAuthService authService)
            {
                this._authService = authService;
            }

            public async Task<CustomResponseDto<bool>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
            {
                await _authService.ForgotPassword(request.Email);
                return CustomResponseDto<bool>.Success((int)HttpStatusCode.OK, true, true);
            }
        }
    }
}
