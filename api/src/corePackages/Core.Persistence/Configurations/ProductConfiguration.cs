using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(LengthContraints.Title);

            builder.Property(p => p.ProductNameKey)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(LengthContraints.DescriptionMaxLength);

            builder.Property(p => p.DescriptionKey)
                .IsRequired(false);

            builder.Property(p => p.ProductCode)
                .IsRequired()
                .HasMaxLength(LengthContraints.Code);

            builder.Property(p => p.StockQuantity)
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.DiscountedUnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Rating)
                .IsRequired();

            builder.HasMany(p => p.ProductSizes)
                .WithOne(ps => ps.Product)
                .HasForeignKey(ps => ps.ProductId);

            builder.HasMany(p => p.ProductColors)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);

            builder.HasMany(p => p.ProductDeliveries)
                .WithOne(pd => pd.Product)
                .HasForeignKey(pd => pd.ProductId);

            builder.HasMany(p => p.ProductUploadedFiles)
                .WithOne(puf => puf.Product)
                .HasForeignKey(puf => puf.ProductId);

            builder.ToTable(TableNameConstants.PRODUCT);
        }
    }
}
