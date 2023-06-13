using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class ContactUsFormRepository : EfRepositoryBase<ContactUsForm, BaseDbContext>, IContactUsFormRepository
    {
        public ContactUsFormRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
