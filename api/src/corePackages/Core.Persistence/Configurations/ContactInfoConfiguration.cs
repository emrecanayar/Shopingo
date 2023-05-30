using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ContactInfoConfiguration : BaseConfiguration<ContactInfo>
    {
        public override void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.AddressText).HasMaxLength(LengthContraints.DescriptionMaxLength).IsRequired();
            builder.Property(x => x.AddressTextKey).HasMaxLength(LengthContraints.KeyMaxLength).IsRequired(false);
            builder.Property(x => x.Phone).HasMaxLength(LengthContraints.PhoneNumber).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(LengthContraints.EmailMaxLength).IsRequired(true);
            builder.Property(x => x.WorkingDay).HasMaxLength(LengthContraints.DescriptionMaxLength).IsRequired(true);
            builder.ToTable(TableNameConstants.CONTACT_INFO);

        }
    }
}