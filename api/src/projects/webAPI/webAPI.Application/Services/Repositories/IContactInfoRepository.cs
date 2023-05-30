using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IContactInfoRepository : IAsyncRepository<ContactInfo>, IRepository<ContactInfo>
    {
    }
}
