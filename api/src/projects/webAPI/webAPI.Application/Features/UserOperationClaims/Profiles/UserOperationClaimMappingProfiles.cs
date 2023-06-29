using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Dtos;
using webAPI.Application.Features.UserOperationClaims.Models;

namespace webAPI.Application.Features.UserOperationClaims.Profiles;

public class UserOperationClaimMappingProfiles : Profile
{
    public UserOperationClaimMappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();
        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
    }
}