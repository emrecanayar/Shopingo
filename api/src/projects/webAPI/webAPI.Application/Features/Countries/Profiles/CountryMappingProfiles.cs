using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Countries.Dtos;
using webAPI.Application.Features.Countries.Models;

namespace webAPI.Application.Features.Countries.Profiles
{
    public class CountryMappingProfiles : Profile
    {
        public CountryMappingProfiles()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryListDto>().ReverseMap();
            CreateMap<IPaginate<Country>, CountryListModel>().ReverseMap();

        }
    }
}
