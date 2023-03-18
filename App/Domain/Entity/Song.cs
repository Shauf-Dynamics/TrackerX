using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Song
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }
    }

    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> entity)
        {
            entity.ToTable("tbl_lt_song");

            entity.Property(e => e.Id)
                .HasColumnName("song_id");

            entity.Property(e => e.Name)
                .HasColumnName("song_name");

            entity.Property(e => e.BandId)
                .HasColumnName("band_id");

            entity.HasOne(e => e.Band)
                .WithMany(e => e.Songs)
                .HasForeignKey(k => k.BandId);
        }
    }
}
