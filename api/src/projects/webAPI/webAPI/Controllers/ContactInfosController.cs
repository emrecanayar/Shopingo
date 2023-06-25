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
using webAPI.Application.Features.ContactInfos.Dtos;
using webAPI.Application.Features.ContactInfos.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class ContactInfosController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<ContactInfo, ContactInfoDto> getByIdContactInfoQuery)
        {
            CustomResponseDto<ContactInfoDto> result = await Mediator.Send(getByIdContactInfoQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<ContactInfo, ContactInfoListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<ContactInfoListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<ContactInfo, ContactInfoListModel> getContactInfoListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<ContactInfoListModel> result = await Mediator.Send(getContactInfoListByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("CreateContactInfo")]
        public async Task<IActionResult> CreateContactInfo([FromBody] ContactInfoCreateDto model)
        {
            CreateCommand<ContactInfo, ContactInfoCreateDto> command = new CreateCommand<ContactInfo, ContactInfoCreateDto>(model);
            CustomResponseDto<ContactInfoCreateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateContactInfo")]
        public async Task<IActionResult> UpdateContactInfo([FromBody] ContactInfoUpdateDto model)
        {
            UpdateCommand<ContactInfo, ContactInfoUpdateDto> command = new UpdateCommand<ContactInfo, ContactInfoUpdateDto>(model);
            CustomResponseDto<ContactInfoUpdateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteContactInfo")]
        public async Task<IActionResult> DeleteContactInfo(ContactInfoDeleteDto model)
        {
            DeleteCommand<ContactInfo, ContactInfoDeleteDto> command = new DeleteCommand<ContactInfo, ContactInfoDeleteDto>(model);
            CustomResponseDto<bool> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}