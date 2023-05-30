using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Seeds
{
    public class OperationClaimSeed : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            OperationClaim[] operationClaimSeeds = { new(Guid.Parse("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), "admin") };
            builder.HasData(operationClaimSeeds);
        }
    }
}
