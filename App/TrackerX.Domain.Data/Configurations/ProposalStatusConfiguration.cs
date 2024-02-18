using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class ProposalStatusConfiguration : BaseEntityTypeConfiguration<ProposalStatus>
{
    public override void Configure(EntityTypeBuilder<ProposalStatus> builder)
    {
        builder.ToTable("tbl_lt_proposal_status");

        builder.HasKey(e => e.ProposalStatusId);

        builder.Property(e => e.ProposalStatusId)
            .HasColumnName("proposal_status_id");

        builder.Property(e => e.ProposalStatusCode)
          .HasColumnName("proposal_status_code");

        builder.Property(e => e.ProposalStatusName)
            .HasColumnName("proposal_status_name");

        base.Configure(builder);
    }
}
