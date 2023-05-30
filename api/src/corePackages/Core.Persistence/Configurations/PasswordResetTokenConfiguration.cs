using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class PasswordResetTokenConfiguration : BaseConfiguration<PasswordResetToken>
    {
        public override void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.PasswordResetTokens).HasForeignKey(x => x.UserId);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(LengthContraints.EmailMaxLength);
            builder.Property(x => x.ClientURI).HasColumnName("ClientURI").HasMaxLength(256);
            builder.Property(x => x.Token).HasColumnName("Token");
            builder.Property(x => x.TokenExpireDate).HasColumnName("TokenExpireDate");
            builder.Property(x => x.IsUsed).HasColumnName("IsUsed").HasDefaultValue(false);
            builder.ToTable(TableNameConstants.PASSWORD_RESET_TOKEN);
        }
    }
}
