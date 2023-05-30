using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class LogRepository : EfRepositoryBase<Log, BaseDbContext>, ILogRepository
    {
        public LogRepository(BaseDbContext context) : base(context)
        {
        }
    }
}