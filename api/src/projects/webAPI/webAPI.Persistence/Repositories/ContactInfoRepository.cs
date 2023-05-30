using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class ContactInfoRepository : EfRepositoryBase<ContactInfo, BaseDbContext>, IContactInfoRepository
    {
        public ContactInfoRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
