using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class MusicProfileConfiguration : BaseEntityTypeConfiguration<MusicProfile>
{ 
    public override void Configure(EntityTypeBuilder<MusicProfile> builder)    
    {
        builder.ToTable("tbl_lt_music_profile");

        builder.HasKey(e => e.MusicProfileId);

        builder.Property(e => e.IsPublished)
          .HasColumnName("music_publicity_ind");

        builder.Property(e => e.AssetId)
            .HasColumnName("music_asset_id");

        builder.Property(e => e.TypeName)
            .HasColumnName("music_type_name")
            .IsRequired(false);

        builder.Property(e => e.CreatorUserId)
            .HasColumnName("music_added_by_id")
            .IsRequired(false);        

        builder.HasOne(e => e.CreatorUser)
            .WithMany()
            .HasForeignKey(c => c.CreatorUserId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
