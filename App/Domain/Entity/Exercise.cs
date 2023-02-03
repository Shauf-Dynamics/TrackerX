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

        public int RecordId { get; set; }

        public Record Record { get; set; }

        public int ExerciseTypeId { get; set; }

        public ExerciseType ExerciseType { get; set; }

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

            entity.Property(e => e.TempoLow)
                .HasColumnName("exercise_tempo_low");

            entity.Property(e => e.TempoHigh)
                .HasColumnName("exercise_tempo_high");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("deleted_ind");

            entity.Property(e => e.RecordId)
                .IsRequired()
                .HasColumnName("record_id");

            entity.Property(e => e.TypeId)
                .IsRequired()
                .HasColumnName("exercise_type_id");

            entity.HasOne(x => x.ExerciseType)
                .WithMany()
                .HasForeignKey(k => k.ExerciseTypeId);

            entity.HasOne(e => e.Record)
                .WithMany(e => e.Exercises)
                .HasForeignKey(k => k.RecordId);
        }
    }
}
