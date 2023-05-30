using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Core.Domain.ComplexTypes.Enums;

namespace Core.Persistence.Seeds
{
    public class UserOperationClaimSeed : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasData(
                new UserOperationClaim { Id = Guid.NewGuid(), OperationClaimId = Guid.Parse("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), UserId = Guid.Parse("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"), Status = RecordStatu.Active, CreatedBy = "System", CreatedDate = new DateTime(2023, 03, 06), ModifiedBy = "", ModifiedDate = null, IsDeleted = false }
                );
        }
    }
}
