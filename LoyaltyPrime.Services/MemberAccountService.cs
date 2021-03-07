using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// The member account service
    /// </summary>
    public class MemberAccountService : IMemberAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberAccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a new member account
        /// </summary>
        /// <param name="member"></param>
        public async Task<int> AddMemberAccountAsync(MemberAccount memberAccount)
        {
            return await this._unitOfWork.MemberAccounts.AddMemberAccountAsync(memberAccount);
        }

        /// <summary>
        /// To collect points to the member account 
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public async Task<int> AddToBalance(MemberAccount memberAccount, int points)
        {
            //TODO: Add validations
            if (!(memberAccount?.MemberID).HasValue)
            {
                //TODO: refactor
                //throw exception from here
                //but return NotFound() from API
            }
            var updatedMemberAccount = await this._unitOfWork.MemberAccounts.GetByIDsAsync(memberAccount.MemberID, memberAccount.AccountID);

            updatedMemberAccount.Balance += points;

            return await this._unitOfWork.MemberAccounts.UpdateMemberAccountAsync(updatedMemberAccount);
        }

        /// <summary>
        /// To redeem points from the member account
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public async Task<int> DeductFromBalance(MemberAccount memberAccount, int points)
        {
            if (!(memberAccount?.MemberID).HasValue)
            {

            }
            var updatedMemberAccount = await this._unitOfWork.MemberAccounts.GetByIDAsync(memberAccount.MemberID);
            memberAccount.Balance -= points;

            return await this._unitOfWork.MemberAccounts.UpdateMemberAccountAsync(memberAccount);
        }


    }
}
