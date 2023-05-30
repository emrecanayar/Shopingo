using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Sizes.Dtos;
using webAPI.Application.Features.Sizes.Models;

namespace webAPI.Application.Features.Sizes.Profiles
{
    public class SizeMappingProfiles : Profile
    {
        public SizeMappingProfiles()
        {
            CreateMap<Size, SizeDeleteDto>().ReverseMap();
            CreateMap<Size, SizeCreateDto>().ReverseMap();
            CreateMap<Size, SizeUpdateDto>().ReverseMap();
            CreateMap<Size, SizeDto>().ReverseMap();
            CreateMap<Size, SizeListDto>().ReverseMap();
            CreateMap<IPaginate<Size>, SizeListModel>().ReverseMap();
        }
    }
}
