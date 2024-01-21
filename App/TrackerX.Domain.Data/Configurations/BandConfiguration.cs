using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

public class BandConfiguration : IEntityTypeConfiguration<Band>
{        
    public void Configure(EntityTypeBuilder<Band> builder)
    {
        builder.ToTable("tbl_lt_band");

        builder.HasKey(e => e.BandId);

        builder.Property(e => e.BandId)
            .HasColumnName("band_id");

        builder.Property(e => e.BandName)
            .HasColumnName("band_name");

        builder.HasMany(e => e.Songs)
            .WithOne(e => e.Band)
            .HasForeignKey(e => e.BandId);
    }
}
