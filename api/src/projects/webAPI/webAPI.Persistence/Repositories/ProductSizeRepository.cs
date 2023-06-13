using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class ProductSizeRepository : EfRepositoryBase<ProductSize, BaseDbContext>, IProductSizeRepository
    {
        public ProductSizeRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

