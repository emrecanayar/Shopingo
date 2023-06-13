using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IProductSizeRepository : IAsyncRepository<ProductSize>, IRepository<ProductSize>
    {
    }
}
