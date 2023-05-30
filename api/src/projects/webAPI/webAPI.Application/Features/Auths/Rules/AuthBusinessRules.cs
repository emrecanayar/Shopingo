using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using webAPI.Application.Features.Auths.Commands.Login;
using webAPI.Application.Features.Auths.Constants;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Services.Repositories;
using webAPI.Application.Services.UserService;
using static Core.Domain.ComplexTypes.Enums;

namespace webAPI.Application.Features.Auths.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public AuthBusinessRules(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<User?> LoginRule(LoginCommand loginCommand)
        {
            User? user = new();
            user = await _userService.GetByEmail(loginCommand.UserLoginDto.UserName);

            if (user is null)
                user = await _userService.GetByUserName(loginCommand.UserLoginDto.UserName);

            if (user is null)
                user = await _userService.GetByRegistrationNumber(loginCommand.UserLoginDto.UserName);

            return user;

        }

        public async Task EmailCantNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            if (user is not null) throw new BusinessException("Mail already exists");
        }

        public Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new BusinessException(AuthMessages.UserDontExists);
            return Task.CompletedTask;
        }

        public Task UserShouldNotBeHaveAuthenticator(User user)
        {
            if (user.AuthenticatorType != AuthenticatorType.None)
                throw new BusinessException(AuthMessages.UserHaveAlreadyAAuthenticator);
            return Task.CompletedTask;
        }

        public async Task UserPasswordShouldBeMatch(Guid id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(AuthMessages.PasswordDontMatch);
        }

        public Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
        {
            if (refreshToken == null) throw new BusinessException(AuthMessages.RefreshDontExists);
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
        {
            if (refreshToken.Revoked != null && DateTime.UtcNow >= refreshToken.Expires)
                throw new BusinessException(AuthMessages.InvalidRefreshToken);
            return Task.CompletedTask;
        }

        public Task OtpAuthenticatorThatVerifiedShouldNotBeExists(OtpAuthenticator? otpAuthenticator)
        {
            if (otpAuthenticator is not null && otpAuthenticator.IsVerified)
                throw new BusinessException(AuthMessages.AlreadyVerifiedOtpAuthenticatorIsExists);
            return Task.CompletedTask;
        }

        public Task EmailAuthenticatorShouldBeExists(EmailAuthenticator? emailAuthenticator)
        {
            if (emailAuthenticator is null) throw new BusinessException(AuthMessages.EmailAuthenticatorDontExists);
            return Task.CompletedTask;
        }

        public Task EmailAuthenticatorActivationKeyShouldBeExists(EmailAuthenticator emailAuthenticator)
        {
            if (emailAuthenticator.ActivationKey is null) throw new BusinessException(AuthMessages.EmailActivationKeyDontExists);
            return Task.CompletedTask;
        }

        public Task OtpAuthenticatorShouldBeExists(OtpAuthenticator? otpAuthenticator)
        {
            if (otpAuthenticator is null) throw new BusinessException(AuthMessages.OtpAuthenticatorDontExists);
            return Task.CompletedTask;
        }

        public Task IsConfirmPasswordForChangePassword(ChangePasswordDto changePasswordDto)
        {
            bool result = changePasswordDto.NewPassword.Equals(changePasswordDto.ConfirmPassword);
            if (result is false) throw new BusinessException(AuthMessages.PasswordDontMatch);

            return Task.CompletedTask;
        }
    }
}