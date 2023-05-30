using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ProductSizeConfiguration : BaseConfiguration<ProductSize>
    {
        public override void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            base.Configure(builder);

            builder.Property(ps => ps.ProductId)
                    .IsRequired();

            builder.Property(ps => ps.SizeId)
                    .IsRequired();

            builder.HasOne(ps => ps.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(ps => ps.ProductId);

            builder.HasOne(ps => ps.Size)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(ps => ps.SizeId);

            builder.ToTable(TableNameConstants.PRODUCT_SIZE);
        }
    }
}
