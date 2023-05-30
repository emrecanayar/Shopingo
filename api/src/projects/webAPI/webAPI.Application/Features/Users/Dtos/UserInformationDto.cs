using static Core.Domain.ComplexTypes.Enums;

namespace webAPI.Application.Features.Users.Dtos
{
    public class UserInformationDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
    }
}