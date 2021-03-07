using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;
using System.Threading.Tasks;

namespace LoyaltyPrime.Data.Repositories
{
    /// <summary>
    /// The member entity repository
    /// </summary>
    public class MemberRepository : Repository<Member>, IMemberRepository
    {

        public MemberRepository(LoyaltyPrimeDbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// For creating a new member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<int> AddMemberAsync(Member member)
        {
            //if ID already exists, then return
            if (member.ID > 0)
                return -1;

            await AddAsync(member);

            return member.ID;
        }

    }
}
