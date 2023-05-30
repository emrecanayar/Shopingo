using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class DeliveryConfiguration : BaseConfiguration<Delivery>
    {
        public override void Configure(EntityTypeBuilder<Delivery> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.DeliveryName)
           .IsRequired()
           .HasMaxLength(255);
        }
    }
}
