using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using System;
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
            var updatedMemberAccount = await RetrieveUpdatedMemberAccount(memberAccount);
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
            var updatedMemberAccount = await RetrieveUpdatedMemberAccount(memberAccount);

            if(updatedMemberAccount.Balance < points)
            {
                throw new Exception($"Sorry, you don't have enough balance to redeem {points} points.");
            }

            updatedMemberAccount.Balance -= points;

            return await this._unitOfWork.MemberAccounts.UpdateMemberAccountAsync(updatedMemberAccount);
        }

        /// <summary>
        /// Retrieves the updated value from the database.
        /// Just to be on the safe side.
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <returns></returns>
        public async Task<MemberAccount> RetrieveUpdatedMemberAccount(MemberAccount memberAccount)
        {
            if (memberAccount is null)
            {
                throw new Exception("Please pass a valid member account entity.");
            }

            var updatedMemberAccount = await this._unitOfWork.MemberAccounts.GetByIDsAsync(memberAccount.MemberID, memberAccount.AccountID);

            //verify if the member account exists
            if (updatedMemberAccount is null)
            {
                throw new Exception($"No member account exists for the Member ID:{memberAccount.MemberID} and Account ID:{memberAccount.AccountID}");
            }

            //verifying if the member account is inactive
            if (!updatedMemberAccount.IsActive)
            {
                throw new Exception("Sorry, please activate your member account.");
            }

            return updatedMemberAccount;
        }
    }
}
