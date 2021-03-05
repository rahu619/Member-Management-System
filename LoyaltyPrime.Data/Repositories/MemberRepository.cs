using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;

namespace LoyaltyPrime.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {

        public MemberRepository(LoyaltyPrimeDbContext dbContext) : base(dbContext)
        {

        }


        /*
         * Methods to filter members
         * 
         */

    }
}
