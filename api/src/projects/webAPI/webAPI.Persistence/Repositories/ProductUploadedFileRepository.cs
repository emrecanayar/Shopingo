using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class ProductUploadedFileRepository : EfRepositoryBase<ProductUploadedFile, BaseDbContext>, IProductUploadedFileRepository
    {
        public ProductUploadedFileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
