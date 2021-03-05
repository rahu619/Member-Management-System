using LoyaltyPrime.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoyaltyPrime.Data.Configurations
{
    class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                   .UseIdentityColumn();

            builder.Property(x => x.CompanyName)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(x => x.Balance)
                   .IsRequired();


            builder.Property(x => x.IsActive)
                   .IsRequired()
                   .HasDefaultValue(false);


            builder.ToTable(nameof(Account));

        }
    }
}
