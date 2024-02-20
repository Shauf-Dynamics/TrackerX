using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class ProposalConfiguration : BaseEntityTypeConfiguration<Proposal>
{
    public override void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.ToTable("tbl_lt_proposal");

        builder.HasKey(e => e.ProposalId);

        builder.Property(e => e.ProposalId)
            .HasColumnName("proposal_id");

        builder.Property(e => e.ProposalStatusId)
            .HasColumnName("proposal_status_id");

        builder.HasOne(e => e.ProposalStatus)
            .WithMany()
            .HasForeignKey(k => k.ProposalStatusId);

        builder.Property(e => e.ProposalAssigneeId)
            .HasColumnName("proposal_assignee_id");

        builder.HasOne(e => e.ProposalAssignee)
            .WithMany()
            .HasForeignKey(k => k.ProposalAssigneeId);

        builder.Property(e => e.ResponseMessage)
            .HasColumnName("response_message")
            .IsRequired(false);

        builder.Property(e => e.AssetId)
            .HasColumnName("asset_id");

        builder.Property(e => e.AssetType)
            .HasColumnName("asset_type");

        base.Configure(builder);
    }
}
