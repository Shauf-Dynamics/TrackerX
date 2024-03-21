using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class CustomMusicConfiguration : BaseEntityTypeConfiguration<CustomMusic>
{
    public override void Configure(EntityTypeBuilder<CustomMusic> builder)
    {
        builder.ToTable("tbl_lt_music");

        builder.HasKey(e => e.CustomMusicId);

        builder.Property(e => e.CustomMusicId)
            .HasColumnName("music_id");

        builder.Property(e => e.CustomMusicDescription)
            .HasColumnName("music_description");

        builder.Property(e => e.AuthorName)
            .HasColumnName("music_author");

        builder.Property(e => e.Year)
            .HasColumnName("year_of_creation");

        builder.Property(e => e.IsOwn)
            .HasColumnName("own_ind");

        builder.Property(e => e.IsInstrumental)
            .HasColumnName("instrumental_ind");

        builder.Property(e => e.Tempo)
            .HasColumnName("tempo");

        builder.Property(e => e.GenreId)
            .HasColumnName("genre_id");   

        builder.HasOne(e => e.Genre)
            .WithMany()
            .HasForeignKey(k => k.GenreId);

        base.Configure(builder);
    }
}
