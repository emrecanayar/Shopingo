using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Categories.Dtos;
using webAPI.Application.Features.Categories.Models;

namespace webAPI.Application.Features.Categories.Profiles
{
    public class CategoryMappingProfiles : Profile
    {
        public CategoryMappingProfiles()
        {
            CreateMap<Category, CategoryDeleteDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
        }
    }
}
