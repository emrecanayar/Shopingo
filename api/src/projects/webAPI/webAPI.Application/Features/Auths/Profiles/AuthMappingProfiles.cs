using AutoMapper;
using Core.Domain.Entities;
using webAPI.Application.Features.Auths.Dtos;

namespace webAPI.Application.Features.Auths.Profiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles()
        {
            CreateMap<RefreshToken, RevokedTokenDto>().ReverseMap();
        }
    }
}
