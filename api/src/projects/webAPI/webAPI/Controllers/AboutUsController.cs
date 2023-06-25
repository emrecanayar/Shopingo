using Core.Application.Base.Queries.GetById;
using Core.Application.Base.Queries.GetList;
using Core.Application.Base.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.AboutUsPage.Dtos;
using webAPI.Application.Features.AboutUsPage.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class AboutUsController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<AboutUs, AboutUsDto> getByIdAboutUsQuery)
        {
            CustomResponseDto<AboutUsDto> result = await Mediator.Send(getByIdAboutUsQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<AboutUs, AboutUsListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<AboutUsListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<AboutUs, AboutUsListModel> getAboutUsListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<AboutUsListModel> result = await Mediator.Send(getAboutUsListByDynamicQuery);
            return Ok(result);
        }
    }
}
