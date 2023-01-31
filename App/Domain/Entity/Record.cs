using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime RecordCreated { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class RecordConfiguration: IEntityTypeConfiguration<Record>
    {        
        public void Configure(EntityTypeBuilder<Record> entity)
        {
            entity.ToTable("tbl_lt_record");

            entity.Property(e => e.Id)
                .HasColumnName("record_id");

            entity.Property(e => e.RecordCreated)
                .IsRequired()
                .HasColumnName("record_date");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("deleted_ind");
        }
    }
}
