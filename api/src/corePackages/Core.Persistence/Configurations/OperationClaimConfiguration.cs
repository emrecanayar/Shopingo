﻿using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class OperationClaimConfiguration : BaseConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired(true).HasMaxLength(LengthContraints.NameMaxLength);
            builder.HasIndex(x => x.Name, "UK_OperationClaims_Name").IsUnique();
            builder.ToTable(TableNameConstants.OPERATION_CLAIM);
        }
    }
}
