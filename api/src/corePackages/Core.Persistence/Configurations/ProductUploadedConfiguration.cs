using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ProductUploadedConfiguration : BaseConfiguration<ProductUploadedFile>
    {
        public override void Configure(EntityTypeBuilder<ProductUploadedFile> builder)
        {
            base.Configure(builder);

            builder.Property(puf => puf.ProductId)
                .IsRequired();

            builder.Property(puf => puf.UploadedFileId)
                .IsRequired();

            builder.HasOne(puf => puf.Product)
                .WithMany(p => p.ProductUploadedFiles)
                .HasForeignKey(puf => puf.ProductId);

            builder.HasOne(puf => puf.UploadedFile)
                .WithMany(puf => puf.ProductUploadedFiles)
                .HasForeignKey(puf => puf.UploadedFileId);

            builder.ToTable(TableNameConstants.PRODUCT_UPLOADED_FILE);
        }
    }
}
