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
using webAPI.Application.Features.Categories.Dtos;
using webAPI.Application.Features.ContactUsForms.Dtos;
using webAPI.Application.Features.ContactUsForms.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class ContactUsFormsController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<ContactUsForm, ContactUsFormDto> getByIdContactUsFormQuery)
        {
            CustomResponseDto<ContactUsFormDto> result = await Mediator.Send(getByIdContactUsFormQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<ContactUsForm, ContactUsFormListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<ContactUsFormListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<ContactUsForm, ContactUsFormListModel> getContactUsFormListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<ContactUsFormListModel> result = await Mediator.Send(getContactUsFormListByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("CreateContactUsForm")]
        public async Task<IActionResult> CreateContactUsForm([FromBody] ContactUsFormCreateDto model)
        {
            CreateCommand<ContactUsForm, ContactUsFormCreateDto> command = new CreateCommand<ContactUsForm, ContactUsFormCreateDto>(model);
            CustomResponseDto<ContactUsFormCreateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateContactUsForm")]
        public async Task<IActionResult> UpdateContactUsForm([FromBody] ContactUsFormUpdateDto model)
        {
            UpdateCommand<ContactUsForm, ContactUsFormUpdateDto> command = new UpdateCommand<ContactUsForm, ContactUsFormUpdateDto>(model);
            CustomResponseDto<ContactUsFormUpdateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteContactUsForm")]
        public async Task<IActionResult> DeleteContactUsForm(ContactUsFormDeleteDto model)
        {
            DeleteCommand<ContactUsForm, ContactUsFormDeleteDto> command = new DeleteCommand<ContactUsForm, ContactUsFormDeleteDto>(model);
            CustomResponseDto<bool> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
