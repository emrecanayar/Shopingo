namespace webAPI.Application.Features.Countries.Dtos
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
        public string NumCode { get; set; }
        public string PhoneCode { get; set; }
        public string Flag { get; set; }
    }
}
