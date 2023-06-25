using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class AboutUsConfiguration : BaseConfiguration<AboutUs>
    {
        public override void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.TitleKey).HasColumnName("TitleKey").IsRequired(true).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.Property(x => x.Title).HasColumnName("Title").IsRequired(true).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.Property(x => x.Content).HasColumnName("Content").IsRequired(true).HasColumnType(LengthContraints.MAX);
            builder.Property(x => x.ContentKey).HasColumnName("ContentKey").IsRequired(true).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.Property(x => x.Content).HasColumnName("Content").IsRequired(true).HasColumnType(LengthContraints.MAX);
            builder.ToTable(TableNameConstants.ABOUT_US);
        }
    }
}
