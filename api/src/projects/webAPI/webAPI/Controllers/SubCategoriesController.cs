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
using webAPI.Application.Features.SubCategories.Dtos;
using webAPI.Application.Features.SubCategories.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class SubCategoriesController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<SubCategory, SubCategoryDto> getByIdSubCategoryQuery)
        {
            CustomResponseDto<SubCategoryDto> result = await Mediator.Send(getByIdSubCategoryQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<SubCategory, SubCategoryListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<SubCategoryListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<SubCategory, SubCategoryListModel> getSubCategoryListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<SubCategoryListModel> result = await Mediator.Send(getSubCategoryListByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("CreateSubCategory")]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryCreateDto model)
        {
            CreateCommand<SubCategory, SubCategoryCreateDto> command = new CreateCommand<SubCategory, SubCategoryCreateDto>(model);
            CustomResponseDto<SubCategoryCreateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateSubCategory")]
        public async Task<IActionResult> UpdateSubCategory([FromBody] SubCategoryUpdateDto model)
        {
            UpdateCommand<SubCategory, SubCategoryUpdateDto> command = new UpdateCommand<SubCategory, SubCategoryUpdateDto>(model);
            CustomResponseDto<SubCategoryUpdateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteSubCategory")]
        public async Task<IActionResult> DeleteSubCategory(SubCategoryDeleteDto model)
        {
            DeleteCommand<SubCategory, SubCategoryDeleteDto> command = new DeleteCommand<SubCategory, SubCategoryDeleteDto>(model);
            CustomResponseDto<bool> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
