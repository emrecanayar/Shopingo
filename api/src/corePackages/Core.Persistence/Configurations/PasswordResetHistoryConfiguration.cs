using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class PasswordResetHistoryConfiguration : BaseConfiguration<PasswordResetHistory>
    {
        public override void Configure(EntityTypeBuilder<PasswordResetHistory> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.PasswordResetHistories).HasForeignKey(x => x.UserId);
            builder.Property(x => x.OldPassword).HasColumnName("OldPassword").HasMaxLength(LengthContraints.PasswordMaxLength);
            builder.Property(x => x.OldPasswordSalt).HasColumnName("OldPasswordSalt").HasMaxLength(LengthContraints.PasswordMaxLength);
            builder.Property(x => x.NewPassword).HasColumnName("NewPassword").HasMaxLength(LengthContraints.PasswordMaxLength);
            builder.Property(x => x.NewPasswordSalt).HasColumnName("NewPasswordSalt").HasMaxLength(LengthContraints.PasswordMaxLength);
            builder.ToTable(TableNameConstants.PASSWORD_RESET_HISTORY);

        }
    }
}
