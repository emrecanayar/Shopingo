using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.CompanyAddresses.Models;
using webAPI.Application.Features.CompanyAddresss.Dtos;

namespace webAPI.Application.Features.CompanyAddresses.Profiles
{
    public class CompanyAddressMappigProfiles : Profile
    {
        public CompanyAddressMappigProfiles()
        {
            CreateMap<CompanyAddress, CompanyAddressDeleteDto>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressCreateDto>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressUpdateDto>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressDto>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressListDto>().ReverseMap();
            CreateMap<IPaginate<CompanyAddress>, CompanyAddressListModel>().ReverseMap();
        }
    }
}
