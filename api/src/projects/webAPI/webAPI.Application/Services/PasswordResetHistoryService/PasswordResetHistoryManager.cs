using Core.Domain.Entities;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Services.PasswordResetHistoryService
{
    public class PasswordResetHistoryManager : IPasswordResetHistoryService
    {
        private readonly IPasswordResetHistoryRepository _passwordResetHistoryRepository;

        public PasswordResetHistoryManager(IPasswordResetHistoryRepository passwordResetHistoryRepository)
        {
            this._passwordResetHistoryRepository = passwordResetHistoryRepository;
        }

        public async Task CreatePasswordResetHistory(PasswordResetHistory passwordResetHistory)
        {
            await this._passwordResetHistoryRepository.AddAsync(passwordResetHistory);
            await Task.CompletedTask;
        }
    }
}
