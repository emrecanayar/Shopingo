using Core.Application.Base.Commands.Create;
using Core.Application.Base.Commands.Delete;
using Core.Application.Base.Commands.Update;
using Core.Application.Base.Queries.GetById;
using Core.Application.Base.Queries.GetList;
using Core.Application.Base.Queries.GetListByDynamic;
using Core.Application.Base.Queries.GetListNavigationProperty;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Categories.Dtos;
using webAPI.Application.Features.Categories.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class CategoriesController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<Category, CategoryDto> getByIdCategoryQuery)
        {
            CustomResponseDto<CategoryDto> result = await Mediator.Send(getByIdCategoryQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<Category, CategoryListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<CategoryListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<Category, CategoryListModel> getCategoryListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<CategoryListModel> result = await Mediator.Send(getCategoryListByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto model)
        {
            CreateCommand<Category, CategoryCreateDto> command = new CreateCommand<Category, CategoryCreateDto>(model, roles: new[] { "admin" }, requiresAuthorization: true);
            CustomResponseDto<CategoryCreateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] ContactUsFormUpdateDto model)
        {
            UpdateCommand<Category, ContactUsFormUpdateDto> command = new UpdateCommand<Category, ContactUsFormUpdateDto>(model);
            CustomResponseDto<ContactUsFormUpdateDto> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(CategoryDeleteDto model)
        {
            DeleteCommand<Category, CategoryDeleteDto> command = new DeleteCommand<Category, CategoryDeleteDto>(model);
            CustomResponseDto<bool> result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetIncludeProperties")]
        public async Task<IActionResult> GetIncludeProperties()
        {
            GetListNavigationPropertyQuery<Category> getNavPropsQuery = new GetListNavigationPropertyQuery<Category>();
            CustomResponseDto<List<string>> result = await Mediator.Send(getNavPropsQuery);
            return Ok(result);
        }

    }
}
