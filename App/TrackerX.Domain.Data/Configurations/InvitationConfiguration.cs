using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{
    internal class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("tbl_lt_user_invitations");

            builder.HasKey(e => e.InvitationId);

            builder.Property(e => e.InvitationId)
                .HasColumnName("user_invitation_id");

            builder.Property(e => e.Code)
                .HasColumnName("user_invitation_code");
            
            builder.Property(e => e.ValideDueDate)
                .HasColumnName("user_invitation_due_date")
                .IsRequired(false);

            builder.Property(e => e.AcceptedDate)
                .HasColumnName("invitation_accepted_date")
                .IsRequired(false);

            builder.Property(e => e.IsInvitationAborted)
                .HasColumnName("invitation_aborted_ind");

            builder.Property(e => e.UserId)
                .HasColumnName("user_invitation_user_id")
                .IsRequired(false);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .IsRequired(false);                
        }
    }
}
