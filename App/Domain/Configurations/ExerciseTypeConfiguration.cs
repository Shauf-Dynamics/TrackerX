using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure.Configurations
{
    internal class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> builder)
        {
            builder.ToTable("tbl_lt_exercise_type");

            builder.Property(e => e.ExerciseTypeId)
                .IsRequired()
                .HasColumnName("exercise_type_id");

            builder.Property(e => e.ExerciseTypeCd)
                .IsRequired()
                .HasColumnName("exercise_type_cd");

            builder.Property(e => e.ExerciseTypeName)
                .IsRequired()
                .HasColumnName("exercise_type_name");
        }
    }
}
