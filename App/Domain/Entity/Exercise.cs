using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity
{
    public class Exercise
    {
        public int Id { get; set; }

        public DateTime Duration { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public int TempoLow { get; set; }

        public int TempoHigh { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity.ToTable("tbl_lt_exercise");

            entity.Property(e => e.Id)
                .HasColumnName("exercise_id");

            entity.Property(e => e.Duration)
                .IsRequired()
                .HasColumnName("exercise_duration");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("exercise_name");

            entity.Property(e => e.TypeId)
                .IsRequired()
                .HasColumnName("exercise_type_id");

            entity.Property(e => e.TempoLow)
                .HasColumnName("exercise_tempo_low");

            entity.Property(e => e.TempoHigh)
                .HasColumnName("exercise_tempo_high");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("deleted_ind");
        }
    }
}
