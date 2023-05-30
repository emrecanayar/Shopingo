using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using webAPI.Application.Features.Auths.Constants;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserIdShouldExistWhenSelected(Guid id)
    {
        User? result = await _userRepository.GetAsync(b => b.Id == id);
        if (result is null) throw new NotFoundException(AuthMessages.UserDontExists);
    }

    public Task UserShouldBeExist(User? user)
    {
        if (user is null) throw new NotFoundException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public Task UserPasswordShouldBeMatch(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }
}