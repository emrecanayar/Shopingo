using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Auths.Commands.ChangePassword;
using webAPI.Application.Features.Auths.Commands.EnableEmailAuthenticator;
using webAPI.Application.Features.Auths.Commands.EnableOtpAuthenticator;
using webAPI.Application.Features.Auths.Commands.ForgotPassword;
using webAPI.Application.Features.Auths.Commands.Login;
using webAPI.Application.Features.Auths.Commands.RefreshTokens;
using webAPI.Application.Features.Auths.Commands.Register;
using webAPI.Application.Features.Auths.Commands.ResetPassword;
using webAPI.Application.Features.Auths.Commands.RevokeToken;
using webAPI.Application.Features.Auths.Commands.VerifyEmailAuthenticator;
using webAPI.Application.Features.Auths.Commands.VerifyOtpAuthenticator;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Users.Dtos;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class AuthsController : BaseController
    {
        private readonly WebAPIConfiguration _configuration;

        public AuthsController(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserLoginDto = userForLoginDto, IPAddress = getIpAddress() };

            CustomResponseDto<LoggedDto> result = await Mediator.Send(loginCommand);

            if (result.Data.RefreshToken is not null) setRefreshTokenToCookie(result.Data.RefreshToken);

            return Ok(result.Data.CreateResponseDto());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegister = userForRegisterDto,
                IpAddress = getIpAddress()
            };

            CustomResponseDto<RegisteredDto> result = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(result.Data.RefreshToken);
            return Created("", result.Data.CreateResponseDto());
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            RefreshTokenCommand refreshTokenCommand = new()
            { RefreshToken = getRefreshTokenFromCookies(), IPAddress = getIpAddress() };
            CustomResponseDto<RefreshedTokensDto> result = await Mediator.Send(refreshTokenCommand);
            setRefreshTokenToCookie(result.Data.RefreshToken);
            return Created("", result.Data.CreateResponseDto());
        }

        [HttpPut("LogOut")]
        public async Task<IActionResult> LogOut(string refreshToken)
        {
            RevokeTokenCommand revokeTokenCommand = new()
            {
                Token = refreshToken ?? getRefreshTokenFromCookies(),
                IPAddress = getIpAddress()
            };
            CustomResponseDto<RevokedTokenDto> result = await Mediator.Send(revokeTokenCommand);
            return Ok(result);
        }

        [HttpGet("EnableEmailAuthenticator")]
        public async Task<IActionResult> EnableEmailAuthenticator()
        {
            EnableEmailAuthenticatorCommand enableEmailAuthenticatorCommand = new()
            {
                UserId = getUserIdFromRequest(),
                VerifyEmailUrlPrefix = $"{_configuration.APIDomain}/Auth/VerifyEmailAuthenticator"
            };
            await Mediator.Send(enableEmailAuthenticatorCommand);

            return Ok();
        }

        [HttpGet("EnableOtpAuthenticator")]
        public async Task<IActionResult> EnableOtpAuthenticator()
        {
            EnableOtpAuthenticatorCommand enableOtpAuthenticatorCommand = new()
            {
                UserId = getUserIdFromRequest()
            };
            EnabledOtpAuthenticatorDto result = await Mediator.Send(enableOtpAuthenticatorCommand);

            return Ok(result);
        }

        [HttpGet("VerifyEmailAuthenticator")]
        public async Task<IActionResult> VerifyEmailAuthenticator([FromQuery] VerifyEmailAuthenticatorCommand verifyEmailAuthenticatorCommand)
        {
            await Mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        [HttpPost("VerifyOtpAuthenticator")]
        public async Task<IActionResult> VerifyOtpAuthenticator([FromBody] string authenticatorCode)
        {
            VerifyOtpAuthenticatorCommand verifyEmailAuthenticatorCommand =
                new() { UserId = getUserIdFromRequest(), ActivationCode = authenticatorCode };

            await Mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand forgotPasswordCommand)
        {
            CustomResponseDto<bool> result = await Mediator.Send(forgotPasswordCommand);
            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand resetPasswordCommand)
        {
            CustomResponseDto<bool> result = await Mediator.Send(resetPasswordCommand);
            return Ok(result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand)
        {
            changePasswordCommand.UserId = getUserIdFromRequest();
            CustomResponseDto<bool> result = await Mediator.Send(changePasswordCommand);
            return Ok(result);
        }

        private string? getRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }

        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}