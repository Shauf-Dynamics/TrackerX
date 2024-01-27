using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrackerX.Domain.Data.Configurations;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property<DateTime?>("CreatedDateTimeUtc")
            .HasColumnName("created_dttm");

        builder.Property<DateTime?>("ModifiedDateTimeUtc")
            .HasColumnName("modified_dttm");

        builder.Property<int?>("CreatedByUserId")
            .HasColumnName("created_by_user_id");

        builder.Property<int?>("ModifiedByUserId")
            .HasColumnName("modified_by_user_id");

        builder.Property<bool>("IsDeleted")
            .HasColumnName("deleled_ind");
    }
}
