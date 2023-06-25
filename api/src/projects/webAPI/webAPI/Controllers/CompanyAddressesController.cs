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
using webAPI.Application.Features.CompanyAddresses.Models;
using webAPI.Application.Features.CompanyAddresss.Dtos;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class CompanyAddressesController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<CompanyAddress, CompanyAddressDto> getByIdCompanyAddressQuery)
        {
            CustomResponseDto<CompanyAddressDto> result = await Mediator.Send(getByIdCompanyAddressQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<CompanyAddress, CompanyAddressListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<CompanyAddressListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<CompanyAddress, CompanyAddressListModel> getCompanyAddressListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<CompanyAddressListModel> result = await Mediator.Send(getCompanyAddressListByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("CreateCompanyAddress")]
        public async Task<IActionResult> CreateCompanyAddress([FromBody] CompanyAddressCreateDto model)
        {
            CreateCommand<CompanyAddress, CompanyAddressCreateDto> command = new CreateCommand<CompanyAddress, CompanyAddressCreateDto>(model);
            CustomResponseDto<CompanyAddressCreateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateCompanyAddress")]
        public async Task<IActionResult> UpdateCompanyAddress([FromBody] CompanyAddressUpdateDto model)
        {
            UpdateCommand<CompanyAddress, CompanyAddressUpdateDto> command = new UpdateCommand<CompanyAddress, CompanyAddressUpdateDto>(model);
            CustomResponseDto<CompanyAddressUpdateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteCompanyAddress")]
        public async Task<IActionResult> DeleteCompanyAddress(CompanyAddressDeleteDto model)
        {
            DeleteCommand<CompanyAddress, CompanyAddressDeleteDto> command = new DeleteCommand<CompanyAddress, CompanyAddressDeleteDto>(model);
            CustomResponseDto<bool> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
