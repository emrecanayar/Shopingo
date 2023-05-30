using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ContactInfo : Entity
    {
        public string AddressText { get; set; }
        public string AddressTextKey { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }

        public ContactInfo()
        {

        }

        public ContactInfo(Guid id, string addessText, string addressTextKey, string phone, string email, string workingDay)
        {
            Id = id;
            AddressText = addessText;
            AddressTextKey = addressTextKey;
            Phone = phone;
            Email = email;
            WorkingDay = workingDay;
        }
    }
}
