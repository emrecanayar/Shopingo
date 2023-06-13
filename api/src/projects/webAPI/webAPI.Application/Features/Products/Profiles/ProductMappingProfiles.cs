using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.Products.Dtos;
using webAPI.Application.Features.Products.Models;

namespace webAPI.Application.Features.Products.Profiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
        }
    }
}
