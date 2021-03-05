using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPrime.Data
{
    public class LoyaltyPrimeDbContext : DbContext
    {
        DbSet<Account> Accounts { get; set; }

        DbSet<Account> Members { get; set; }

        public LoyaltyPrimeDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }

    }
}
