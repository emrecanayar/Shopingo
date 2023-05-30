using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ProductUploadedFile : Entity
    {
        public Guid ProductId { get; set; }
        public Guid UploadedFileId { get; set; }
        public Product Product { get; set; }
        public UploadedFile UploadedFile { get; set; }

        public ProductUploadedFile()
        {

        }

        public ProductUploadedFile(Guid id, Guid productId, Guid uploadedFileId)
        {
            Id = id;
            ProductId = productId;
            UploadedFileId = uploadedFileId;
        }
    }
}
