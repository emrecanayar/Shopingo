using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IProductUploadedFileRepository : IAsyncRepository<ProductUploadedFile>, IRepository<ProductUploadedFile>
    {
    }
}
