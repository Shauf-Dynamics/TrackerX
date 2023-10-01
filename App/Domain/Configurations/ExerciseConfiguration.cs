using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("tbl_lt_exercise");

            builder.Property(e => e.Id)
                .HasColumnName("exercise_id");

            builder.Property(e => e.Duration)
                .IsRequired()
                .HasColumnName("exercise_duration");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("exercise_name");

            builder.Property(e => e.TempoLow)
                .HasColumnName("exercise_tempo_low");

            builder.Property(e => e.TempoHigh)
                .HasColumnName("exercise_tempo_high");

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("deleted_ind");

            builder.Property(e => e.RecordId)
                .IsRequired()
                .HasColumnName("record_id");

            builder.Property(e => e.TypeId)
                .IsRequired()
                .HasColumnName("exercise_type_id");

            builder.HasOne(x => x.ExerciseType)
                .WithMany()
                .HasForeignKey(k => k.ExerciseTypeId);

            builder.HasOne(e => e.Record)
                .WithMany(e => e.Exercises)
                .HasForeignKey(k => k.RecordId);
        }
    }
}
