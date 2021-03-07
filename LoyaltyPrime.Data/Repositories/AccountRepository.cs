using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;
using System.Threading.Tasks;

namespace LoyaltyPrime.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(LoyaltyPrimeDbContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<int> AddAccountAsync(Account account)
        {
            //Verifying if the company name already exists
            var existingAccount = await SingleAsync(x => x.CompanyName.ToLower().Equals(account.CompanyName.ToLower()));
            if (existingAccount != null)
            {
                return existingAccount.ID;
            }

            await AddAsync(account);

            //else return the newly created Account ID
            return account.ID;
        }

    }
}
