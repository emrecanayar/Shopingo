using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class StaticTextConfiguration : BaseConfiguration<StaticText>
    {
        public override void Configure(EntityTypeBuilder<StaticText> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.DescriptionKey).HasColumnName("DescriptionKey").HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("text");
            builder.ToTable(TableNameConstants.STATIC_TEXT);
        }
    }
}
