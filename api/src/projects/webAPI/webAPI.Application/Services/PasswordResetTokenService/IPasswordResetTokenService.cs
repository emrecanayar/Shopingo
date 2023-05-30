using Core.Domain.Entities;

namespace webAPI.Application.Services.PasswordResetTokenService
{
    public interface IPasswordResetTokenService
    {
        Task CreatePasswordResetToken(PasswordResetToken passwordResetToken);
        Task<PasswordResetToken> GetPasswordResetToken(string token);
    }
}
