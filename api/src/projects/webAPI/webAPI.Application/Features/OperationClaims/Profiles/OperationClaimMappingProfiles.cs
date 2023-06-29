using AutoMapper;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using webAPI.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using webAPI.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using webAPI.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using webAPI.Application.Features.OperationClaims.Dtos;
using webAPI.Application.Features.OperationClaims.Models;

namespace webAPI.Application.Features.OperationClaims.Profiles
{
    public class OperationClaimMappingProfiles : Profile
    {
        public OperationClaimMappingProfiles()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        }
    }
}
