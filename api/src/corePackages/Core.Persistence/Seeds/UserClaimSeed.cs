using Core.Domain.Entities;
using Core.Helpers.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Core.Domain.ComplexTypes.Enums;

namespace Core.Persistence.Seeds
{
    public class UserClaimSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("password", out passwordHash, out passwordSalt);
            builder.HasData(
                new User { Id = Guid.Parse("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"), FirstName = "Admin", LastName = "Admin", Email = "admin@admin.com", PasswordSalt = passwordSalt, PasswordHash = passwordHash, AuthenticatorType = AuthenticatorType.None, CultureType = CultureType.US, UserType = UserType.MainUser, Status = RecordStatu.Active, CreatedBy = "System", CreatedDate = new DateTime(2023, 03, 06), ModifiedBy = "", ModifiedDate = null, IsDeleted = false }
                );
        }
    }
}
