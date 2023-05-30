using static Core.Domain.ComplexTypes.Enums;

namespace Application.Features.Users.Dtos;

public class CreatedUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string RegistrationNumber { get; set; }
    public UserType UserType { get; set; }
}