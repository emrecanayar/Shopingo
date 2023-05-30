using Core.Domain.Entities;

namespace webAPI.Application.Services.PasswordResetHistoryService
{
    public interface IPasswordResetHistoryService
    {
        Task CreatePasswordResetHistory(PasswordResetHistory passwordResetHistory);
    }
}
