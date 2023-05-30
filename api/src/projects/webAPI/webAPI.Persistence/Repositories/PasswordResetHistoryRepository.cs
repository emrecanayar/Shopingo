using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class PasswordResetHistoryRepository : EfRepositoryBase<PasswordResetHistory, BaseDbContext>, IPasswordResetHistoryRepository
    {
        public PasswordResetHistoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
