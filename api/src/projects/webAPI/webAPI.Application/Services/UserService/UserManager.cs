using Application.Features.Users.Dtos;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            IPaginate<User> users = await _userRepository.GetListAsync();
            List<UserDto> mappedUserDto = ObjectMapper.Mapper.Map<List<UserDto>>(users.Items);

            return mappedUserDto;
        }

        public async Task<User?> GetByEmail(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetById(Guid id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            return user;
        }

        public async Task<User?> GetByRegistrationNumber(string registrationNumber)
        {
            User? user = await _userRepository.GetAsync(u => u.RegistrationNumber == registrationNumber);
            return user;
        }

        public async Task<User?> GetByUserName(string userName)
        {
            User? user = await _userRepository.GetAsync(u => u.UserName == userName);
            return user;
        }

        public async Task<User> GetUserInformation(Guid id)
        {

            User? user = await _userRepository.GetAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> Update(User user)
        {
            User updatedUser = await _userRepository.UpdateAsync(user);
            return updatedUser;
        }
    }
}