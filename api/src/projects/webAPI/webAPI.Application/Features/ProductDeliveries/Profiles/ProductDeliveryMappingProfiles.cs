using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.ProductDeliveries.Dtos;
using webAPI.Application.Features.ProductDeliveries.Models;

namespace webAPI.Application.Features.ProductDeliveries.Profiles
{
    public class ProductDeliveryMappingProfiles : Profile
    {
        public ProductDeliveryMappingProfiles()
        {
            CreateMap<ProductDelivery, ProductDeliveryDto>().ReverseMap();
            CreateMap<ProductDelivery, ProductDeliveryListDto>().ReverseMap();
            CreateMap<IPaginate<ProductDelivery>, ProductDeliveryListModel>().ReverseMap();
        }
    }
}
