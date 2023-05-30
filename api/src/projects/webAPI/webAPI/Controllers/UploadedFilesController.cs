using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Features.UploadedFiles.Commands.UploadFile;
using webAPI.Application.Features.UploadedFiles.Dtos;
using webAPI.Application.Features.UploadedFiles.Queries.GetUploadedFileByToken;
using webAPI.Controllers.Base;

namespace webAPI.Controllers
{
    public class UploadedFilesController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        public UploadedFilesController(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            CustomResponseDto<UploadedFileCreatedDto> result = await Mediator.Send(new UploadFileCommand { File = file, WebRootPath = _environment.WebRootPath });
            return Created("", result);
        }

        [HttpPost("GetFile")]
        public async Task<IActionResult> GetFile(GetUploadedFileByTokenQuery getUploadedFileByTokenQuery)
        {
            CustomResponseDto<UploadedFileDto> result = await Mediator.Send(getUploadedFileByTokenQuery);
            return Ok(result.Data);
        }
    }
}
