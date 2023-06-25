using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface ICompanyAddressRepository : IAsyncRepository<CompanyAddress>, IRepository<CompanyAddress>
    {
    }
}
