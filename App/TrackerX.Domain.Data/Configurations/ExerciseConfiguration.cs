using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("tbl_lt_exercises");

        builder.HasKey(e => e.ExerciseId);

        builder.Property(e => e.ExerciseId)
            .HasColumnName("exercise_id");

        builder.Property(e => e.Duration)
            .IsRequired()
            .HasColumnName("exercise_duration");

        builder.Property(e => e.Description)
            .IsRequired()
            .HasColumnName("exercise_description");

        builder.Property(e => e.TempoLow)
            .HasColumnName("exercise_tempo_low");

        builder.Property(e => e.TempoHigh)
            .HasColumnName("exercise_tempo_high");

        builder.Property(e => e.TempoTypeId)
            .HasColumnName("tempo_type_id");

        builder.HasOne(x => x.TempoType)
            .WithMany()
            .HasForeignKey(k => k.TempoTypeId);

        builder.Property(e => e.ExerciseTypeId)
            .HasColumnName("exercise_type_id");

        builder.HasOne(x => x.ExerciseType)
            .WithMany()
            .HasForeignKey(k => k.ExerciseTypeId);

        builder.Property(e => e.SongId)
            .IsRequired(false)
            .HasColumnName("song_id");

        builder.HasOne(x => x.Song)
            .WithMany()
            .HasForeignKey(k => k.SongId);

        builder.Property(e => e.LessonId)
            .IsRequired()
            .HasColumnName("lesson_id");

        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.Exercises)
            .HasForeignKey(k => k.LessonId);
    }
}
