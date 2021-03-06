using LoyaltyPrime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPrime.Data
{
    public class LoyaltyPrimeDbContext : DbContext
    {
        public LoyaltyPrimeDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Account> Accounts { get; set; }

        DbSet<Member> Members { get; set; }

        DbSet<MemberAccount> MemberAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberAccount>()
                        .HasKey(x => new { x.MemberID, x.AccountID });

            //modelBuilder.ApplyConfiguration(new MemberConfiguration());
            //modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }

    }
}
