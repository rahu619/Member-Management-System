using LoyaltyPrime.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoyaltyPrime.Data.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                   .UseIdentityColumn();

            builder.Property(x => x.FirstName)
                   .IsRequired();

            builder.Property(x => x.LastName)
                    .IsRequired();

            builder.Property(x => x.Address)
                    .IsRequired();

            builder.ToTable(nameof(Member));
        }
    }
}
