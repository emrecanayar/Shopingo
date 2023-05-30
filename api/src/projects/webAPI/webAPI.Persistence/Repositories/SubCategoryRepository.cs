using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using webAPI.Application.Services.Repositories;

namespace webAPI.Persistence.Repositories
{
    public class SubCategoryRepository : EfRepositoryBase<SubCategory, BaseDbContext>, ISubCategoryRepository
    {
        public SubCategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
