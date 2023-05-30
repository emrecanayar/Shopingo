using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class SizeConfiguration : BaseConfiguration<Size>
    {
        public override void Configure(EntityTypeBuilder<Size> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.SizeName)
            .IsRequired()
            .HasMaxLength(LengthContraints.Code);


            builder.ToTable(TableNameConstants.SIZE);
        }
    }
}
