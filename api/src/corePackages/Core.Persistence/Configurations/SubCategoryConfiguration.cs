using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class SubCategoryConfiguration : BaseConfiguration<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.SubCategoryName).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.Property(x => x.Key).HasMaxLength(LengthContraints.KeyMaxLength);
            builder.HasOne(x => x.Category).WithMany(x => x.SubCategories).HasForeignKey(x => x.CategoryId);
            builder.ToTable(TableNameConstants.SUB_CATEGORY);
        }
    }
}