using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Core.Application.Requests;
using Core.Application.ResponseTypes.Concrete;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.Users.Commands.CreateUser;
using webAPI.Application.Features.Users.Commands.DeleteUser;
using webAPI.Application.Features.Users.Commands.UpdateUser;
using webAPI.Application.Features.Users.Commands.UpdateUserFromAuth;
using webAPI.Application.Features.Users.Dtos;
using webAPI.Application.Features.Users.Queries.GetByIdUser;
using webAPI.Application.Features.Users.Queries.GetByIdUserInformation;
using webAPI.Application.Features.Users.Queries.GetListUser;
using webAPI.Application.Features.Users.Queries.GetListUserByDynamic;
using webAPI.Controllers.Base;

namespace webAPI.API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            UserDto result = await Mediator.Send(getByIdUserQuery);
            return Ok(result);
        }

        [HttpGet("GetFromAuth")]
        public async Task<IActionResult> GetFromAuth()
        {
            GetByIdUserQuery getByIdUserQuery = new() { Id = getUserIdFromRequest() };
            UserDto result = await Mediator.Send(getByIdUserQuery);
            return Ok(result);
        }

        [HttpGet("GetUserInformation")]
        public async Task<IActionResult> GetUserInformation()
        {

            GetByIdUserInformationQuery getByIdUserInformationQuery = new() { UserId = getUserIdFromRequest() };
            CustomResponseDto<UserInformationDto> result = await Mediator.Send(getByIdUserInformationQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                          [FromBody] Dynamic? dynamic = null)
        {
            GetListUserByDynamicQuery getListUserByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            CustomResponseDto<UserListModel> result = await Mediator.Send(getListUserByDynamicQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
            CreatedUserDto result = await Mediator.Send(createUserCommand);
            return Created("", result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdatedUserDto result = await Mediator.Send(updateUserCommand);
            return Ok(result);
        }

        [HttpPut("FromAuth")]
        public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
        {
            updateUserFromAuthCommand.Id = getUserIdFromRequest();
            UpdatedUserFromAuthDto result = await Mediator.Send(updateUserFromAuthCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
        {
            DeletedUserDto result = await Mediator.Send(deleteUserCommand);
            return Ok(result);
        }
    }
}