using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired(true).HasMaxLength(LengthContraints.NameMaxLength);
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired(true).HasMaxLength(LengthContraints.NameMaxLength);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired(true).HasMaxLength(LengthContraints.EmailMaxLength);
            builder.Property(x => x.UserName).HasColumnName("UserName").IsRequired(false).HasMaxLength(LengthContraints.EmailMaxLength);
            builder.Property(x => x.RegistrationNumber).HasColumnName("RegistrationNumber").IsRequired(false).HasMaxLength(LengthContraints.EmailMaxLength);
            builder.Property(x => x.CountryId).HasColumnName("CountryId").IsRequired().HasDefaultValue(Guid.Parse("D3B9F1F7-491B-4A4A-ABBD-9C3ED3DD722C"));
            builder.HasIndex(x => x.Email, "UK_Users_Email").IsUnique();
            builder.HasIndex(x => x.UserName, "UK_Users_UserName").IsUnique();
            builder.HasIndex(x => x.RegistrationNumber, "UK_Users_RegistrationNumber").IsUnique();
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired(true).HasMaxLength(LengthContraints.PasswordMaxLength);
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").HasMaxLength(LengthContraints.PasswordMaxLength);
            builder.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType").HasConversion<int>();
            builder.Property(x => x.CultureType).HasColumnName("CultureType").HasConversion<int>();
            builder.HasMany(x => x.UserOperationClaims);
            builder.HasMany(x => x.RefreshTokens);
            builder.HasOne(x => x.Country).WithMany(x => x.Users).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableNameConstants.USER);
        }
    }
}
