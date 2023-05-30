using Core.Domain.Entities;
using webAPI.Application.Services.Repositories;
using webAPI.Application.Services.UserService;

namespace webAPI.Application.Services.PasswordResetTokenService
{
    public class PasswordResetTokenManager : IPasswordResetTokenService
    {
        private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
        private readonly IPasswordResetHistoryRepository _passwordResetHistoryRepository;
        private readonly IUserService _userService;

        public PasswordResetTokenManager(IPasswordResetTokenRepository passwordResetTokenRepository, IPasswordResetHistoryRepository passwordResetHistoryRepository, IUserService userService)
        {
            this._passwordResetTokenRepository = passwordResetTokenRepository;
            this._passwordResetHistoryRepository = passwordResetHistoryRepository;
            this._userService = userService;
        }

        public async Task CreatePasswordResetToken(PasswordResetToken passwordResetToken)
        {
            PasswordResetToken addedPasswordResetToken = await this._passwordResetTokenRepository.AddAsync(passwordResetToken);
            await Task.CompletedTask;
        }

        public async Task<PasswordResetToken> GetPasswordResetToken(string token)
        {
            PasswordResetToken? passwordResetToken = await this._passwordResetTokenRepository.GetAsync(x => !x.IsUsed && x.TokenExpireDate > DateTime.Now && x.Token == token);
            return passwordResetToken;
        }
    }
}
