using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class CountryConfiguration : BaseConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Iso).HasColumnName("Iso").HasMaxLength(2);
            builder.Property(x => x.Key).HasColumnName("Key").HasMaxLength(LengthContraints.KeyMaxLength);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(LengthContraints.NameMaxLength);
            builder.Property(x => x.Iso3).HasColumnName("Iso3").HasMaxLength(3);
            builder.Property(x => x.NumCode).HasColumnName("NumCode").HasMaxLength(6);
            builder.Property(x => x.PhoneCode).HasColumnName("PhoneCode").HasMaxLength(5);
            builder.Property(x => x.Flag).HasColumnName("Flag");
            builder.ToTable(TableNameConstants.COUNTRY);
        }
    }
}
