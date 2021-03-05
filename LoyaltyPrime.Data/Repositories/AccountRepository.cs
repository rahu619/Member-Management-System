using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;

namespace LoyaltyPrime.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(LoyaltyPrimeDbContext dbContext) : base(dbContext) { }


    }
}
