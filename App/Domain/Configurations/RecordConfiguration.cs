using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure.Configurations
{
    internal class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable("tbl_lt_record");

            builder.Property(e => e.Id)
                .HasColumnName("record_id");

            builder.Property(e => e.RecordCreated)
                .IsRequired()
                .HasColumnName("record_date");

            /*           builder.Property(e => e.OwnerId)
                           .IsRequired()
                           .HasColumnName("owner_id");*/

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("deleted_ind");

            builder.HasMany(e => e.Exercises)
                .WithOne(e => e.Record)
                .HasForeignKey(k => k.RecordId);
        }
    }
}
