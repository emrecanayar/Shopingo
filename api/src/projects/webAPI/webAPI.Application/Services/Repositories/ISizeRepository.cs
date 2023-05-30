using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface ISizeRepository : IAsyncRepository<Size>, IRepository<Size>
    {

    }
}
