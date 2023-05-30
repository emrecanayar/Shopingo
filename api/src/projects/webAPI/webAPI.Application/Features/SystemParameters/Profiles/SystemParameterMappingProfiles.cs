using Application.Features.SystemParameters.Dtos;
using Application.Features.SystemParameters.Models;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SystemParameters.Profiles;

public class SystemParameterMappingProfiles : Profile
{
    public SystemParameterMappingProfiles()
    {
        CreateMap<SystemParameter, SystemParameterDto>().ReverseMap();
        CreateMap<SystemParameter, SystemParameterListDto>().ReverseMap();
        CreateMap<IPaginate<SystemParameter>, SystemParameterListModel>().ReverseMap();
    }
}