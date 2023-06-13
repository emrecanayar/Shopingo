using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ProductCategoryConfiguration : BaseConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.Property(pc => pc.ProductId)
             .IsRequired();

            builder.Property(pc => pc.CategoryId)
             .IsRequired();

            builder.HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            builder.HasOne(pc => pc.SubCategory)
                .WithMany()
                .HasForeignKey(pc => pc.SubCategoryId)
                .IsRequired(false);


            builder.ToTable(TableNameConstants.PRODUCT_CATEGORY);
        }
    }
}
