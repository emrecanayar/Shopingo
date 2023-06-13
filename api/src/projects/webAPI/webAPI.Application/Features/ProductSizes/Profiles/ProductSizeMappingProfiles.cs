using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.ProductSizes.Dtos;
using webAPI.Application.Features.ProductSizes.Models;

namespace webAPI.Application.Features.ProductSizes.Profiles
{
    public class ProductSizeMappingProfiles : Profile
    {
        public ProductSizeMappingProfiles()
        {
            CreateMap<ProductSize, ProductSizeDto>().ReverseMap();
            CreateMap<ProductSize, ProductSizeListDto>().ReverseMap();
            CreateMap<IPaginate<ProductSize>, ProductSizeListModel>().ReverseMap();
        }
    }
}
