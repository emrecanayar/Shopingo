using static Core.Domain.ComplexTypes.Enums;

namespace Application.Features.Users.Dtos;

public class UserListDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string RegistrationNumber { get; set; }
    public RecordStatu Status { get; set; }
    public UserType UserType { get; set; }
    public Guid CountryId { get; set; }
    public Guid CountryDto { get; set; }
}