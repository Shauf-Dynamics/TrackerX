using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime RegistrationDttm { get; set; }

        public bool IsDeactivated { get; set; }

        public int RoleId { get; set; }
    }

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("tbl_lt_account");

            entity.Property(e => e.Id)
                .HasColumnName("account_id");

            entity.Property(e => e.Name)
                .HasColumnName("account_name");

            entity.Property(e => e.Name)
                .HasColumnName("account_token");

            entity.Property(e => e.RegistrationDttm)
                .HasColumnName("registration_dttm");

            entity.Property(e => e.IsDeactivated)
                .HasColumnName("is_deactivated");
        }
    }
}
