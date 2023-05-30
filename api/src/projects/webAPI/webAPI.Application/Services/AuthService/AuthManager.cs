using Application.Features.SystemParameters.Dtos;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using Core.Mailing;
using Core.Persistence.Paging;
using Core.Security.EmailAuthenticator;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using webAPI.Application.Features.Auths.Dtos;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Services.PasswordResetHistoryService;
using webAPI.Application.Services.PasswordResetTokenService;
using webAPI.Application.Services.Repositories;
using webAPI.Application.Services.SystemParameterService;
using webAPI.Application.Services.UserService;
using static Core.Domain.ComplexTypes.Enums;

namespace webAPI.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
        private readonly IOtpAuthenticatorHelper _otpAuthenticatorHelper;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IMailService _mailService;
        private readonly IUserService _userService;
        private readonly IPasswordResetTokenService _passwordResetTokenService;
        private readonly IPasswordResetHistoryService _passwordResetHistoryService;
        private readonly TokenOptions _tokenOptions;
        private readonly AuthBusinessRules _authBusinessRules;
        private const string str_ClientApplicationResetPasswordUri = "ClientApplicationResetPasswordUri";

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository, IConfiguration configuration, IEmailAuthenticatorHelper emailAuthenticatorHelper, IOtpAuthenticatorHelper otpAuthenticatorHelper, IEmailAuthenticatorRepository emailAuthenticatorRepository, IOtpAuthenticatorRepository otpAuthenticatorRepository, IMailService mailService, ISystemParameterService systemParameterService, AuthBusinessRules authBusinessRules, IUserService userService, IPasswordResetTokenService passwordResetTokenService, IPasswordResetHistoryService passwordResetHistoryService)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _emailAuthenticatorHelper = emailAuthenticatorHelper;
            _otpAuthenticatorHelper = otpAuthenticatorHelper;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _otpAuthenticatorRepository = otpAuthenticatorRepository;
            _mailService = mailService;
            _systemParameterService = systemParameterService;
            _authBusinessRules = authBusinessRules;
            _userService = userService;
            _passwordResetTokenService = passwordResetTokenService;
            _passwordResetHistoryService = passwordResetHistoryService;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<string> ConvertSecretKeyToString(byte[] secretKey)
        {
            string result = await _otpAuthenticatorHelper.ConvertSecretKeyToString(secretKey);
            return result;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == user.Id, include: x => x.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(x => new OperationClaim
            {
                Id = x.OperationClaim.Id,
                Name = x.OperationClaim.Name
            }).ToList();

            AccessToken accessToken = await _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
        {
            EmailAuthenticator emailAuthenticator = new()
            {
                UserId = user.Id,
                ActivationKey = await _emailAuthenticatorHelper.CreateEmailActivationKey(),
                IsVerified = false
            };

            return emailAuthenticator;
        }

        public async Task<OtpAuthenticator> CreateOtpAuthenticator(User user)
        {
            OtpAuthenticator otpAuthenticator = new()
            {
                UserId = user.Id,
                SecretKey = await _otpAuthenticatorHelper.GenerateSecretKey(),
                IsVerified = false
            };

            return otpAuthenticator;
        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = await _tokenHelper.CreateRefreshToken(user, ipAddress);
            return refreshToken;
        }

        public async Task DeleteOldRefreshTokens(Guid userId)
        {
            IList<RefreshToken> refreshTokens = (await _refreshTokenRepository.GetListAsync(r =>
                                               r.UserId == userId &&
                                               r.Revoked == null && r.Expires >= DateTime.UtcNow &&
                                               r.Created.AddDays(_tokenOptions.RefreshTokenTTL) <=
                                               DateTime.UtcNow)
                                          ).Items;
            foreach (RefreshToken refreshToken in refreshTokens) await _refreshTokenRepository.DeleteAsync(refreshToken);
        }

        public async Task ForgotPassword(string email)
        {
            User? user = await _userService.GetByEmail(email);
            await _authBusinessRules.UserShouldBeExists(user);
            SystemParameterDto systemParameter = await _systemParameterService.GetByKey(str_ClientApplicationResetPasswordUri);
            PasswordResetToken passwordResetToken = await generatePasswordResetToken(user, systemParameter.ParameterValue);
            await _passwordResetTokenService.CreatePasswordResetToken(passwordResetToken);
            if (!string.IsNullOrEmpty(passwordResetToken.Token))
            {
                var param = new Dictionary<string, string>
                           {
                            {"token", passwordResetToken.Token },
                            {"email", email}
                           };

                //Mail içeriğine eklenebilir.
                string url = QueryHelpers.AddQueryString(systemParameter.ParameterValue, param);

                var toEmailList = new List<MailboxAddress>
                {
                new("${user.FirstName} {user.LastName}",user.Email)
                };

                _mailService.SendMail(new Mail
                {
                    ToList = toEmailList,
                    Subject = "Forgot Password - runflow",
                    TextBody = $"Change Password: {url}"
                });
            }

            await Task.CompletedTask;
        }

        public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
        {
            RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(r => r.Token == token);
            return refreshToken;
        }

        public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
        {
            RefreshToken childToken = await _refreshTokenRepository.GetAsync(r => r.Token == refreshToken.ReplacedByToken);

            if (childToken != null && childToken.Revoked != null && childToken.Expires <= DateTime.UtcNow)
                await RevokeRefreshToken(childToken, ipAddress, reason);
            else await RevokeDescendantRefreshTokens(childToken, ipAddress, reason);
        }

        public async Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null,
                                        string? replacedByToken = null)
        {
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReasonRevoked = reason;
            refreshToken.ReplacedByToken = replacedByToken;
            await _refreshTokenRepository.UpdateAsync(refreshToken);
        }

        public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = await _tokenHelper.CreateRefreshToken(user, ipAddress);
            await RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        public async Task SendAuthenticatorCode(User user)
        {
            if (user.AuthenticatorType is AuthenticatorType.Email) await sendAuthenticatorCodeWithEmail(user);
        }

        public async Task VerifyAuthenticatorCode(User user, string authenticatorCode)
        {
            if (user.AuthenticatorType is AuthenticatorType.Email)
                await verifyAuthenticatorCodeWithEmail(user, authenticatorCode);
            else if (user.AuthenticatorType is AuthenticatorType.Otp)
                await verifyAuthenticatorCodeWithOtp(user, authenticatorCode);
        }

        private async Task sendAuthenticatorCodeWithEmail(User user)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

            string authenticatorCode = await _emailAuthenticatorHelper.CreateEmailActivationCode();
            emailAuthenticator.ActivationKey = authenticatorCode;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            var toEmailList = new List<MailboxAddress>
             {
                new("${user.FirstName} {user.LastName}",user.Email)
             };

            _mailService.SendMail(new Mail
            {
                ToList = toEmailList,
                Subject = "Authenticator Code - runflow",
                TextBody = $"Enter your authenticator code: {authenticatorCode}"
            });
        }

        public async Task ResetPassword(string token, string password)
        {
            PasswordResetToken passwordResetToken = await _passwordResetTokenService.GetPasswordResetToken(token);

            if (passwordResetToken != null)
            {
                User user = await this._userService.GetById(passwordResetToken.UserId);
                passwordResetToken.IsUsed = true;
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                PasswordResetHistory passwordResetHistory = new()
                {
                    UserId = user.Id,
                    OldPasswordSalt = user.PasswordSalt.ToString(),
                    OldPassword = user.PasswordHash.ToString(),
                    NewPassword = passwordHash.ToString(),
                    NewPasswordSalt = passwordSalt.ToString()
                };
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _passwordResetHistoryService.CreatePasswordResetHistory(passwordResetHistory);
            }
        }

        public async Task ChangePassword(Guid userId, ChangePasswordDto changePasswordDto)
        {
            await _authBusinessRules.UserPasswordShouldBeMatch(userId, changePasswordDto.Password);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out passwordHash, out passwordSalt);
            User? user = await _userService.GetById(userId);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userService.Update(user);

            await Task.CompletedTask;
        }

        private async Task verifyAuthenticatorCodeWithEmail(User user, string authenticatorCode)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            if (emailAuthenticator.ActivationKey != authenticatorCode)
                throw new BusinessException("Authenticator code is invalid.");

            emailAuthenticator.ActivationKey = null;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
        }

        private async Task verifyAuthenticatorCodeWithOtp(User user, string authenticatorCode)
        {
            OtpAuthenticator otpAuthenticator = await _otpAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            bool result = await _otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, authenticatorCode);

            if (!result)
                throw new BusinessException("Authenticator code is invalid.");
        }

        private async Task<PasswordResetToken> generatePasswordResetToken(User user, string clientURI)
        {
            DateTime expireDate = DateTime.Now.AddDays(1);
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == user.Id, include: x => x.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(x => new OperationClaim
            {
                Id = x.OperationClaim.Id,
                Name = x.OperationClaim.Name
            }).ToList();

            AccessToken accessToken = await _tokenHelper.CreateToken(user, operationClaims);
            return new PasswordResetToken()
            {
                Email = user.Email,
                ClientURI = clientURI,
                IsUsed = false,
                Token = accessToken.Token,
                UserId = user.Id,
                TokenExpireDate = expireDate
            };
        }
    }
}