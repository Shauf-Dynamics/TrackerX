using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{
    internal class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> entity)
        {
            entity.ToTable("tbl_lt_song");

            entity.Property(e => e.SongId)
                .HasColumnName("song_id");

            entity.Property(e => e.SongName)
                .HasColumnName("song_name");

            entity.Property(e => e.WritingYear)
                .HasColumnName("year_of_creation");

            entity.Property(e => e.IsInstrumental)
                .HasColumnName("instrumental_ind");

            entity.Property(e => e.GenreId)
                .HasColumnName("genre_id");

            entity.Property(e => e.Tempo)
                .HasColumnName("tempo");

            entity.HasOne(e => e.Genre)
                .WithMany()
                .HasForeignKey(k => k.GenreId);

            entity.Property(e => e.BandId)
                .HasColumnName("band_id");

            entity.HasOne(e => e.Band)
                .WithMany(e => e.Songs)
                .HasForeignKey(k => k.BandId);
        }
    }
}
