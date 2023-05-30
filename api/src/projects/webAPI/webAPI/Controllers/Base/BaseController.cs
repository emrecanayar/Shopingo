using Core.Application.ResponseTypes.Concrete;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace webAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        protected string? getIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }

        protected Guid getUserIdFromRequest()
        {
            Guid userId = HttpContext.User.GetUserId();
            return userId;
        }

        protected Guid getCompanyIdFromRequest()
        {
            Guid companyId = HttpContext.User.GetCompanyId();
            return companyId;
        }

        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == (int)HttpStatusCode.NoContent)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
