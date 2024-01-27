using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class SongConfiguration : BaseEntityTypeConfiguration<Song>
{
    public override void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("tbl_lt_song");

        builder.HasKey(e => e.SongId);

        builder.Property(e => e.SongId)
            .HasColumnName("song_id");

        builder.Property(e => e.SongName)
            .HasColumnName("song_name");

        builder.Property(e => e.WritingYear)
            .HasColumnName("year_of_creation");

        builder.Property(e => e.IsInstrumental)
            .HasColumnName("instrumental_ind");

        builder.Property(e => e.GenreId)
            .HasColumnName("genre_id");

        builder.Property(e => e.Tempo)
            .HasColumnName("tempo");

        builder.HasOne(e => e.Genre)
            .WithMany()
            .HasForeignKey(k => k.GenreId);

        builder.Property(e => e.BandId)
            .HasColumnName("band_id");

        builder.HasOne(e => e.Band)
            .WithMany(e => e.Songs)
            .HasForeignKey(k => k.BandId);

        builder.Property(e => e.AlbumId)
            .HasColumnName("album_id")
            .IsRequired(false);

        builder.HasOne(e => e.Album)
            .WithMany(e => e.Songs)
            .HasForeignKey(k => k.AlbumId);

        base.Configure(builder);
    }
}
