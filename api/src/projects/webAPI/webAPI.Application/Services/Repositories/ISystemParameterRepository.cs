using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface ISystemParameterRepository : IAsyncRepository<SystemParameter>, IRepository<SystemParameter>
    {
    }
}
