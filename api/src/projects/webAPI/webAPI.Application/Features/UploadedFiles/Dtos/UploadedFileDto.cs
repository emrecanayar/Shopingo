using static Core.Domain.ComplexTypes.Enums;

namespace webAPI.Application.Features.UploadedFiles.Dtos
{
    public class UploadedFileDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string FileName { get; set; }
        public string? Directory { get; set; } = null;
        public string Path { get; set; }
        public string Extension { get; set; }
        public FileType? FileType { get; set; } = null;
    }
}
