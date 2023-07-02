using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class CountryRepository : EfRepositoryBase<Country, BaseDbContext>, ICountryRepository
    {
        public CountryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
