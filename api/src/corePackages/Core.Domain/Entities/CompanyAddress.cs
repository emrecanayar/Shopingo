using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CompanyAddress : Entity
    {
        public string AddressText { get; set; }
        public string AddressTextKey { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }


        public CompanyAddress()
        {

        }
        public CompanyAddress(Guid id, string addessText, string addressTextKey, string phone, string email, string workingDay, string latitude, string longitude)
        {
            Id = id;
            AddressText = addessText;
            AddressTextKey = addressTextKey;
            Phone = phone;
            Email = email;
            WorkingDay = workingDay;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
