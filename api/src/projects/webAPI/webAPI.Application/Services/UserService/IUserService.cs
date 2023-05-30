using Application.Features.Users.Dtos;
using Core.Domain.Entities;

namespace webAPI.Application.Services.UserService
{
    public interface IUserService
    {
        public Task<User?> GetByEmail(string email);
        public Task<User?> GetByRegistrationNumber(string registrationNumber);
        public Task<User?> GetByUserName(string userName);
        public Task<User> GetById(Guid id);
        public Task<User> Update(User user);
        public Task<User> GetUserInformation(Guid id);
        public Task<List<UserDto>> GetUsers();
    }
}
