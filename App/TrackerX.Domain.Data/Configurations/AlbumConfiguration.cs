using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{    
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("tbl_lt_album");

            builder.HasKey(e => e.AlbumId);

            builder.Property(e => e.AlbumId)
                .HasColumnName("album_id");

            builder.Property(e => e.AlbumName)
                .HasColumnName("album_name");

            builder.Property(e => e.WritingYear)
                .HasColumnName("year_of_creation");

            builder.HasMany(e => e.Musics)
                .WithOne(e => e.Album)
                .HasForeignKey(e => e.AlbumId);

            builder.Property(e => e.GenreId)
                .HasColumnName("genre_id");

            builder.HasOne(e => e.Genre)
                .WithMany()
                .HasForeignKey(e => e.GenreId);

            builder.Property(e => e.BandId)
                .HasColumnName("band_id");

            builder.HasOne(e => e.Band)
                .WithMany()
                .HasForeignKey(e => e.BandId);
        }
    }
}
