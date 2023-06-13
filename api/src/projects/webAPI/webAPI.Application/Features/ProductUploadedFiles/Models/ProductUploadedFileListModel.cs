using Core.Persistence.Paging;
using webAPI.Application.Features.ProductUploadedFiles.Dtos;

namespace webAPI.Application.Features.ProductUploadedFiles.Models
{
    public class ProductUploadedFileListModel : BasePageableModel
    {
        public IList<ProductUploadedFileListDto> Items { get; set; }
    }
}
