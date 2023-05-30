using Core.Application.Base.Commands.Create;
using Core.Application.Base.Commands.Delete;
using Core.Application.Base.Commands.Update;
using Core.Application.Base.Queries.GetById;
using Core.Application.Base.Queries.GetList;
using Core.Application.Base.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Sizes.Dtos;
using webAPI.Application.Features.Sizes.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class SizesController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<Size, SizeDto> getByIdSizeQuery)
        {
            CustomResponseDto<SizeDto> result = await Mediator.Send(getByIdSizeQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<Size, SizeListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<SizeListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<Size, SizeListModel> getSizeListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<SizeListModel> result = await Mediator.Send(getSizeListByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("CreateSize")]
        public async Task<IActionResult> CreateSize([FromBody] SizeCreateDto model)
        {
            CreateCommand<Size, SizeCreateDto> command = new CreateCommand<Size, SizeCreateDto>(model);
            CustomResponseDto<SizeCreateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateSize")]
        public async Task<IActionResult> UpdateSize([FromBody] SizeUpdateDto model)
        {
            UpdateCommand<Size, SizeUpdateDto> command = new UpdateCommand<Size, SizeUpdateDto>(model);
            CustomResponseDto<SizeUpdateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteSize")]
        public async Task<IActionResult> DeleteSize(SizeDeleteDto model)
        {
            DeleteCommand<Size, SizeDeleteDto> command = new DeleteCommand<Size, SizeDeleteDto>(model);
            CustomResponseDto<bool> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
