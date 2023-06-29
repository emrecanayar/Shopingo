using Core.Security.Extensions;
using Microsoft.AspNetCore.Http;

namespace webAPI.Application.Services.UserService
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _accessor;

        public UserAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid LoggedInUserId => GetUserId();

        private Guid GetUserId()
        {
            Guid userId = _accessor.HttpContext.User.GetUserId();
            return userId;
        }
    }
}
