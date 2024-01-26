using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations;

internal class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
{
    public void Configure(EntityTypeBuilder<RoleType> builder)
    {
        builder.ToTable("tbl_ad_user_role");

        builder.HasKey(e => e.RoleTypeId);

        builder.Property(e => e.RoleTypeId)
            .HasColumnName("user_role_id");

        builder.Property(e => e.RoleTypeCode)
            .HasColumnName("user_role_code");

        builder.Property(e => e.RoleTypeName)
            .HasColumnName("user_role_name");
    }
}
