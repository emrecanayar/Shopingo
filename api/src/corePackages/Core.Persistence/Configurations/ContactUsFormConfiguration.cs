using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class ContactUsFormConfiguration : BaseConfiguration<ContactUsForm>
    {
        public override void Configure(EntityTypeBuilder<ContactUsForm> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(LengthContraints.NameMaxLength);


            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(LengthContraints.EmailMaxLength);


            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20);


            builder.Property(c => c.Message)
                .IsRequired().
                HasMaxLength(LengthContraints.DescriptionMaxLength);


            builder.HasOne(c => c.User)
                .WithMany(c => c.ContactUsForms)
                .HasForeignKey(c => c.UserId)
                .IsRequired(false);

            builder.ToTable(TableNameConstants.CONTACT_US_FORM);
        }
    }
}
