namespace webAPI.Application.Services.UserService
{
    public interface IUserAccessor
    {
        Guid LoggedInUserId { get; }
    }
}
