using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class CompanyAddressRepository : EfRepositoryBase<CompanyAddress, BaseDbContext>, ICompanyAddressRepository
    {
        public CompanyAddressRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
