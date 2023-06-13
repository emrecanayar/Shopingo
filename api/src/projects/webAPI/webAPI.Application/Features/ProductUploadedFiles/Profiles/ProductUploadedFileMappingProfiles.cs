using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.ProductUploadedFiles.Dtos;
using webAPI.Application.Features.ProductUploadedFiles.Models;

namespace webAPI.Application.Features.ProductUploadedFiles.Profiles
{
    public class ProductUploadedFileMappingProfiles : Profile
    {
        public ProductUploadedFileMappingProfiles()
        {
            CreateMap<ProductUploadedFile, ProductUploadedFileDto>().ReverseMap();
            CreateMap<ProductUploadedFile, ProductUploadedFileListDto>().ReverseMap();
            CreateMap<IPaginate<ProductUploadedFile>, ProductUploadedFileListModel>().ReverseMap();
        }
    }
}
