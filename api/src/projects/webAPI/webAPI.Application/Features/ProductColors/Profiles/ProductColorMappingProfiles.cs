using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.ProductColors.Dtos;
using webAPI.Application.Features.ProductColors.Models;

namespace webAPI.Application.Features.ProductColors.Profiles
{
    public class ProductColorMappingProfiles : Profile
    {
        public ProductColorMappingProfiles()
        {
            CreateMap<ProductColor, ProductColorDto>().ReverseMap();
            CreateMap<ProductColor, ProductColorListDto>().ReverseMap();
            CreateMap<IPaginate<ProductColor>, ProductColorListModel>().ReverseMap();
        }
    }
}
