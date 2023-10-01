using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("tbl_lt_account");

            builder.Property(e => e.Id)
                .HasColumnName("account_id");

            builder.Property(e => e.Name)
                .HasColumnName("account_name");

            builder.Property(e => e.Name)
                .HasColumnName("account_token");

            builder.Property(e => e.RegistrationDttm)
                .HasColumnName("registration_dttm");

            builder.Property(e => e.IsDeactivated)
                .HasColumnName("is_deactivated");
        }
    }
}
