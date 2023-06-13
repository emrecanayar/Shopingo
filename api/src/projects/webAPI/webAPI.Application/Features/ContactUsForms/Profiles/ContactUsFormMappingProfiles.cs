using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Categories.Dtos;
using webAPI.Application.Features.ContactUsForms.Dtos;
using webAPI.Application.Features.ContactUsForms.Models;

namespace webAPI.Application.Features.ContactUsForms.Profiles
{
    public class ContactUsFormMappingProfiles : Profile
    {
        public ContactUsFormMappingProfiles()
        {
            CreateMap<ContactUsForm, ContactUsFormDeleteDto>().ReverseMap();
            CreateMap<ContactUsForm, ContactUsFormCreateDto>().ReverseMap();
            CreateMap<ContactUsForm, ContactUsFormUpdateDto>().ReverseMap();
            CreateMap<ContactUsForm, ContactUsFormDto>().ReverseMap();
            CreateMap<ContactUsForm, ContactUsFormListDto>().ReverseMap();
            CreateMap<IPaginate<ContactUsForm>, ContactUsFormListModel>().ReverseMap();
        }
    }
}
