using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class PasswordResetTokenRepository : EfRepositoryBase<PasswordResetToken, BaseDbContext>, IPasswordResetTokenRepository
    {
        public PasswordResetTokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
