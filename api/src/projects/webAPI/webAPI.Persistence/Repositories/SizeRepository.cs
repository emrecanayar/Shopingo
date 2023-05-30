using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class SizeRepository : EfRepositoryBase<Size, BaseDbContext>, ISizeRepository
    {
        public SizeRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
