﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class ExerciseTypeConfiguration : BaseEntityTypeConfiguration<ExerciseType>
{
    public override void Configure(EntityTypeBuilder<ExerciseType> builder)
    {
        builder.ToTable("tbl_ad_exercise_type");

        builder.HasKey(e => e.ExerciseTypeId);

        builder.Property(e => e.ExerciseTypeId)
            .IsRequired()
            .HasColumnName("exercise_type_id");

        builder.Property(e => e.ExerciseTypeCode)
            .IsRequired()
            .HasColumnName("exercise_type_cd");

        builder.Property(e => e.ExerciseTypeName)
            .IsRequired()
            .HasColumnName("exercise_type_name");

        base.Configure(builder);
    }
}
