using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ProductDeliveryConfiguration : BaseConfiguration<ProductDelivery>
    {
        public override void Configure(EntityTypeBuilder<ProductDelivery> builder)
        {
            base.Configure(builder);

            builder.Property(pd => pd.ProductId)
                .IsRequired();

            builder.Property(pd => pd.DeliveryId)
                .IsRequired();

            builder.HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDeliveries)
                .HasForeignKey(pd => pd.ProductId);

            builder.HasOne(pd => pd.Delivery)
                .WithMany(pd => pd.ProductDeliveries)
                .HasForeignKey(pd => pd.DeliveryId);

            builder.ToTable(TableNameConstants.PRODUCT_DELIVERY);
        }
    }
}
