using Core.Application.Base.Queries.GetListNavigationProperty;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Dtos;
using webAPI.Application.Features.UserOperationClaims.Models;
using webAPI.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;
using webAPI.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using webAPI.Controllers.Base;

namespace webAPI.WebAPI.Controllers
{
    public class UserOperationClaimsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
        {
            UserOperationClaimDto result = await Mediator.Send(getByIdUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpGet("GetIncludeProperties")]
        public async Task<IActionResult> GetIncludeProperties()
        {
            GetListNavigationPropertyQuery<UserOperationClaim> getNavPropsQuery = new GetListNavigationPropertyQuery<UserOperationClaim>();
            CustomResponseDto<List<string>> result = await Mediator.Send(getNavPropsQuery);
            return Ok(result);
        }
    }
}