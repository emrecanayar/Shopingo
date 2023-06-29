namespace webAPI.Application.Features.Auths.Dtos
{
    public class RevokedTokenDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
    }
}
