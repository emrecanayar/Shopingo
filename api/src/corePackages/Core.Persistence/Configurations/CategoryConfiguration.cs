using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CategoryName).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.Property(x => x.Key).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.ToTable(TableNameConstants.CATEGORY);
        }
    }
}