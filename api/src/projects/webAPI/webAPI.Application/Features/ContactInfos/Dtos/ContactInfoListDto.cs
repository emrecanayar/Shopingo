﻿namespace webAPI.Application.Features.ContactInfos.Dtos
{
    public class ContactInfoListDto
    {
        public Guid Id { get; set; }
        public string AddressText { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkingDay { get; set; }
    }
}
