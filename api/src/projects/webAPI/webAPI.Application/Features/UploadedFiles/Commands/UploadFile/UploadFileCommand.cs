﻿using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;
using webAPI.Application.Features.UploadedFiles.Dtos;
using webAPI.Application.Features.UploadedFiles.Rules;
using webAPI.Application.Services.UploadedFileService;

namespace webAPI.Application.Features.UploadedFiles.Commands.UploadFile
{
    public class UploadFileCommand : IRequest<CustomResponseDto<UploadedFileCreatedDto>>
    {
        public IFormFile File { get; set; }
        public string WebRootPath { get; set; }

        public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, CustomResponseDto<UploadedFileCreatedDto>>
        {
            private readonly string UPLOADEDFILE_FOLDER = Path.Combine("Resources", "UploadedFiles", "DocumentPool");
            private readonly IUploadedFileService _uploadedFileService;
            private readonly UploadedFileBusinessRules _uploadedFileBusinessRules;

            public UploadFileCommandHandler(IUploadedFileService uploadedFileService, UploadedFileBusinessRules uploadedFileBusinessRules)
            {
                _uploadedFileService = uploadedFileService;
                _uploadedFileBusinessRules = uploadedFileBusinessRules;
            }

            public async Task<CustomResponseDto<UploadedFileCreatedDto>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                string filePath = FileHelper.GenerateURLForFile(request.File, request.WebRootPath, UPLOADEDFILE_FOLDER);
                UploadedFile uploadedFile = await this._uploadedFileService.AddOrUpdateDocument(new UploadedFileDto
                {
                    FileType = this._uploadedFileBusinessRules.DetectFileType(filePath),
                    FileName = request.File.FileName,
                    Path = filePath,
                    Extension = FileInfoHelper.GetFileExtension(filePath),
                    Directory = request.File.Name,
                });

                FileHelper.Upload(request.File, request.WebRootPath, filePath);
                return CustomResponseDto<UploadedFileCreatedDto>.Success((int)HttpStatusCode.Created, new UploadedFileCreatedDto { Path = filePath, Token = uploadedFile.Token }, true);
            }
        }
    }
}
