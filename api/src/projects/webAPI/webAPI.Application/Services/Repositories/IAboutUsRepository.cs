using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IAboutUsRepository : IAsyncRepository<AboutUs>, IRepository<AboutUs>
    {
    }
}
