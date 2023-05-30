using Core.Domain.Entities.Base;
using static Core.Domain.ComplexTypes.Enums;

namespace Core.Domain.Entities
{
    public class UploadedFile : Entity
    {
        public string Token { get; set; }
        public string FileName { get; set; }
        public string? Directory { get; set; } = null;
        public string Path { get; set; }
        public string Extension { get; set; }
        public FileType? FileType { get; set; } = null;
        public ICollection<ProductUploadedFile> ProductUploadedFiles { get; set; }

        public UploadedFile()
        {
            ProductUploadedFiles = new HashSet<ProductUploadedFile>();
        }

        public UploadedFile(Guid id, string token, string fileName, string? directory, string path, string extension, FileType? fileType)
        {
            Id = id;
            Token = token;
            FileName = fileName;
            Directory = directory;
            Path = path;
            Extension = extension;
            FileType = fileType;
        }
    }
}
