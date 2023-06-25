using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.AboutUsPage.Dtos;
using webAPI.Application.Features.AboutUsPage.Models;

namespace webAPI.Application.Features.AboutUsPage.Profiles
{
    public class AboutUsMappingProfiles : Profile
    {
        public AboutUsMappingProfiles()
        {
            CreateMap<AboutUs, AboutUsDto>().ReverseMap();
            CreateMap<AboutUs, AboutUsListDto>().ReverseMap();
            CreateMap<IPaginate<AboutUs>, AboutUsListModel>().ReverseMap();
        }
    }
}
