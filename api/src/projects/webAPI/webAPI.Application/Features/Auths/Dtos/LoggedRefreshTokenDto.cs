namespace webAPI.Application.Features.Auths.Dtos
{
    public class LoggedRefreshTokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
