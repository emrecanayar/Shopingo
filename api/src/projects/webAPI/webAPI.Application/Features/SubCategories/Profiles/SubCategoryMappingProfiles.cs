using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.SubCategories.Dtos;
using webAPI.Application.Features.SubCategories.Models;

namespace webAPI.Application.Features.SubCategories.Profiles
{
    public class SubCategoryMappingProfiles : Profile
    {
        public SubCategoryMappingProfiles()
        {
            CreateMap<SubCategory, SubCategoryDeleteDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryCreateDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryUpdateDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryListDto>().ReverseMap();
            CreateMap<IPaginate<SubCategory>, SubCategoryListModel>().ReverseMap();
        }
    }
}
