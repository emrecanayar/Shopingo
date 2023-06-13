namespace webAPI.Application.Features.ContactUsForms.Dtos
{
    public class ContactUsFormCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
    }
}
