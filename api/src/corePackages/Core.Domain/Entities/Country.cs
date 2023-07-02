using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Country : Entity
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
        public string NumCode { get; set; }
        public string PhoneCode { get; set; }
        public string Flag { get; set; }

        public Country()
        {

        }

        public Country(Guid id, string iso, string key, string name, string iso3, string numCode, string phoneCode, string flag) : this()
        {
            Id = id;
            Iso = iso;
            Key = key;
            Name = name;
            Iso3 = iso3;
            NumCode = numCode;
            PhoneCode = phoneCode;
            Flag = flag;
        }
    }
}
