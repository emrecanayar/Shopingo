using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ProductColorConfiguration : BaseConfiguration<ProductColor>
    {
        public override void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            base.Configure(builder);

            builder.Property(pc => pc.ProductId)
                   .IsRequired();

            builder.Property(pc => pc.ColorId)
                   .IsRequired();

            builder.HasOne(pc => pc.Product)
                   .WithMany(p => p.ProductColors)
                   .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(pc => pc.Color)
                   .WithMany(p => p.ProductColors)
                   .HasForeignKey(pc => pc.ColorId);

            builder.ToTable(TableNameConstants.PRODUCT_COLOR);
        }
    }
}
