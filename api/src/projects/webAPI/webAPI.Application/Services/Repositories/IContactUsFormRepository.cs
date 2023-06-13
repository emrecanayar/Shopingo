using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace webAPI.Application.Services.Repositories
{
    public interface IContactUsFormRepository : IAsyncRepository<ContactUsForm>, IRepository<ContactUsForm>
    {
    }
}
