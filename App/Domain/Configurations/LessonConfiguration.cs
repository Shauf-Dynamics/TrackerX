using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{
    internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("tbl_lt_lessons");

            builder.HasKey(e => e.LessonId);

            builder.Property(e => e.LessonId)
                .HasColumnName("lesson_id");

            builder.Property(e => e.LessonDate)
                .HasColumnName("lesson_date");
        }
    }
}
