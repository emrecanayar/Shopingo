using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using webAPI.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using webAPI.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using webAPI.Application.Features.OperationClaims.Dtos;
using webAPI.Application.Features.OperationClaims.Models;
using webAPI.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using webAPI.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using webAPI.Controllers.Base;

namespace webAPI.WebAPI.Controllers
{
    public class OperationClaimsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            CustomResponseDto<OperationClaimDto> result = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            CustomResponseDto<OperationClaimListModel> result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CustomResponseDto<CreatedOperationClaimDto> result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result.Data.CreateResponseDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            CustomResponseDto<UpdatedOperationClaimDto> result = await Mediator.Send(updateOperationClaimCommand);
            return Created("", result.Data.CreateResponseDto());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            CustomResponseDto<DeletedOperationClaimDto> result = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(result.Data.CreateResponseDto());
        }
    }
}