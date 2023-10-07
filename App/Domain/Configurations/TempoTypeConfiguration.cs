using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{
    internal class TempoTypeConfiguration : IEntityTypeConfiguration<TempoType>
    {
        public void Configure(EntityTypeBuilder<TempoType> builder)
        {
            builder.ToTable("tbl_ad_tempo_type");

            builder.HasKey(e => e.TempoTypeId);

            builder.Property(e => e.TempoTypeId)
                .HasColumnName("tempo_type_id");

            builder.Property(e => e.TempoTypeCode)
                .HasColumnName("tempo_type_code");

            builder.Property(e => e.TempoTypeName)
                .HasColumnName("tempo_type_name");

        }
    }
}
