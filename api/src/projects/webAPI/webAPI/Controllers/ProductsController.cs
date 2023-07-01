using Core.Application.Base.Queries.GetById;
using Core.Application.Base.Queries.GetList;
using Core.Application.Base.Queries.GetListByDynamic;
using Core.Application.Base.Queries.GetListNavigationProperty;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Products.Dtos;
using webAPI.Application.Features.Products.Models;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdQuery<Product, ProductDto> getByIdProductQuery)
        {
            CustomResponseDto<ProductDto> result = await Mediator.Send(getByIdProductQuery);
            return Ok(result);
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] IncludeProperty includeProperty)
        {
            GetListQuery<Product, ProductListModel> getListQuery = new() { PageRequest = pageRequest, IncludeProperty = includeProperty };
            CustomResponseDto<ProductListModel> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamicInclude")]
        public async Task<IActionResult> GetListByDynamicInclude([FromQuery] PageRequest pageRequest,
                                                                 [FromBody] DynamicIncludeProperty? dynamicIncludeProperty = null)
        {
            GetListByDynamicQuery<Product, ProductListModel> getProductListByDynamicQuery = new() { PageRequest = pageRequest, DynamicIncludeProperty = dynamicIncludeProperty };
            CustomResponseDto<ProductListModel> result = await Mediator.Send(getProductListByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("GetIncludeProperties")]
        public async Task<IActionResult> GetIncludeProperties()
        {
            GetListNavigationPropertyQuery<Product> getNavPropsQuery = new GetListNavigationPropertyQuery<Product>();
            CustomResponseDto<List<string>> result = await Mediator.Send(getNavPropsQuery);
            return Ok(result);
        }
    }
}
