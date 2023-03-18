using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Band
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }

    public class BandConfiguration : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> entity)
        {
            entity.ToTable("tbl_lt_band");

            entity.Property(e => e.Id)
                .HasColumnName("band_id");

            entity.Property(e => e.Name)
                .HasColumnName("band_name");

            entity.HasMany(e => e.Songs)
                .WithOne(e => e.Band)
                .HasForeignKey(e => e.BandId);
        }
    }
}
