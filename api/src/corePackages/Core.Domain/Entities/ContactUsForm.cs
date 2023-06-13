using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ContactUsForm : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public ContactUsForm()
        {

        }

        public ContactUsForm(string fullName, string email, string phoneNumber, string message, Guid? userId)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
            UserId = userId;
        }
    }
}
