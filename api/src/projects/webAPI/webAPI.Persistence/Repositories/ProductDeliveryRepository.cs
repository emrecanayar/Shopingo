using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class ProductDeliveryRepository : EfRepositoryBase<ProductDelivery, BaseDbContext>, IProductDeliveryRepository
    {
        public ProductDeliveryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

