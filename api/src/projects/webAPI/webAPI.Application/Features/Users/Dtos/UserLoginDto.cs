namespace webAPI.Application.Features.Users.Dtos
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? AuthenticatorCode { get; set; }
    }
}