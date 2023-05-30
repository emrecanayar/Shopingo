using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ColorConfiguration : BaseConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.ColorName)
                   .IsRequired()
                   .HasMaxLength(LengthContraints.Title);

            builder.ToTable(TableNameConstants.COLOR);
        }
    }
}
