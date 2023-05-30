using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IPasswordResetHistoryRepository : IAsyncRepository<PasswordResetHistory>, IRepository<PasswordResetHistory>
    {
    }
}
