﻿namespace webAPI.Application.Features.CompanyAddresss.Dtos
{
    public class CompanyAddressCreateDto
    {
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
