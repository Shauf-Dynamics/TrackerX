using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("tbl_ad_genre");

            builder.Property(e => e.GenreId)
                .HasColumnName("genre_id");

            builder.Property(e => e.GenreName)
                .HasColumnName("genre_name");

            builder.Property(e => e.ParentGenreId)
                .HasColumnName("genre_parent_id")
                .IsRequired(false);            

            builder.HasMany(e => e.Subgenres)
                .WithOne(e => e.ParentGenre)
                .HasForeignKey(k => k.ParentGenreId);
        }
    }
}
