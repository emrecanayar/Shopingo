using Application.Features.Users.Dtos;

namespace webAPI.Application.Features.ContactUsForms.Dtos
{
    public class ContactUsFormListDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public UserDto? User { get; set; }
    }
}
