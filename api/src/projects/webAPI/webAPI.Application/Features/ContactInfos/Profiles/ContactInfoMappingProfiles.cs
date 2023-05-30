using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.ContactInfos.Dtos;
using webAPI.Application.Features.ContactInfos.Models;

namespace webAPI.Application.Features.ContactInfos.Profiles
{
    public class ContactInfoMappingProfiles : Profile
    {
        public ContactInfoMappingProfiles()
        {
            CreateMap<ContactInfo, ContactInfoDeleteDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoCreateDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoUpdateDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoListDto>().ReverseMap();
            CreateMap<IPaginate<ContactInfo>, ContactInfoListModel>().ReverseMap();
        }
    }
}
