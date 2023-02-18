using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ExerciseType
    {
        public int ExerciseTypeId { get; set; }

        public string ExerciseTypeCd { get; set; }

        public string ExerciseTypeName { get; set; }
    }

    public class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> entity)
        {
            entity.ToTable("tbl_lt_exercise_type");

            entity.Property(e => e.ExerciseTypeId)
                .IsRequired()
                .HasColumnName("exercise_type_id");

            entity.Property(e => e.ExerciseTypeCd)
                .IsRequired()
                .HasColumnName("exercise_type_cd");

            entity.Property(e => e.ExerciseTypeName)
                .IsRequired()
                .HasColumnName("exercise_type_name");
        }
    }
}
