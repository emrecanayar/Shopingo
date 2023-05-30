using Core.Domain.Entities;
using Core.Security.JWT;
using webAPI.Application.Features.Auths.Dtos;

namespace webAPI.Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);

        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);

        public Task<RefreshToken?> GetRefreshTokenByToken(string token);

        public Task DeleteOldRefreshTokens(Guid userId);

        public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);

        public Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null,
                               string? replacedByToken = null);

        public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress);

        public Task<EmailAuthenticator> CreateEmailAuthenticator(User user);

        public Task<OtpAuthenticator> CreateOtpAuthenticator(User user);

        public Task<string> ConvertSecretKeyToString(byte[] secretKey);

        public Task SendAuthenticatorCode(User user);

        public Task VerifyAuthenticatorCode(User user, string authenticatorCode);

        public Task ForgotPassword(string email);

        public Task ResetPassword(string token, string password);

        public Task ChangePassword(Guid userId, ChangePasswordDto changePasswordDto);
    }
}