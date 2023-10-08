using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbl_lt_users");

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("user_name");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("user_email");

            builder.Property(e => e.PasswordHash)
                .IsRequired()
                .HasColumnName("user_password_hash"); 
            
            builder.Property(e => e.RegistrationDttm)
                 .IsRequired()
                 .HasColumnName("user_registration_date");

            builder.Property(e => e.RoleTypeId)
                .IsRequired()
                .HasColumnName("user_role_id");

            builder.HasOne(e => e.RoleType)
                .WithMany()
                .HasForeignKey(k => k.RoleTypeId);
        }
    }
}
