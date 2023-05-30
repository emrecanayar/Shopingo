using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface ISubCategoryRepository : IAsyncRepository<SubCategory>, IRepository<SubCategory>
    {
    }
}
