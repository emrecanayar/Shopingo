using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class AboutUsRepository : EfRepositoryBase<AboutUs, BaseDbContext>, IAboutUsRepository
    {
        public AboutUsRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
