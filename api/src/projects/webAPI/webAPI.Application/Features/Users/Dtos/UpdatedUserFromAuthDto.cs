using Core.Security.JWT;

namespace Application.Features.Users.Dtos;

public class UpdatedUserFromAuthDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string RegistrationNumber { get; set; }
    public AccessToken AccessToken { get; set; }
}