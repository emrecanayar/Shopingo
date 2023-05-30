using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IPasswordResetTokenRepository : IAsyncRepository<PasswordResetToken>, IRepository<PasswordResetToken>
    {
    }
}
