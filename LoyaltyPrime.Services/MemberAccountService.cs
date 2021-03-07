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
        /// <param name="memberAccount"></param>
        public async Task<int> AddMemberAccountAsync(MemberAccount memberAccount)
        {
            var fetchedMemberAccount = await RetrieveMemberAccount(memberAccount);
            if (fetchedMemberAccount != null)
            {
                //In an ideal scenario this will be a custom exception class
                throw new Exception("Member Account already exists!");
            }
            return await this._unitOfWork.MemberAccounts.AddMemberAccountAsync(memberAccount);
        }

        /// <summary>
        /// To collect points to the member account 
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public async Task<int> AddToBalance(MemberAccount memberAccount, int points)
        {
            var fetchedMemberAccount = await RetrieveMemberAccount(memberAccount);

            ValidatingBeforeUpdatingTheBalance(fetchedMemberAccount);

            fetchedMemberAccount.Balance += points;

            return await this._unitOfWork.MemberAccounts.UpdateMemberAccountAsync(fetchedMemberAccount);
        }

        /// <summary>
        /// To redeem points from the member account
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public async Task<int> DeductFromBalance(MemberAccount memberAccount, int points)
        {
            var fetchedMemberAccount = await RetrieveMemberAccount(memberAccount);

            ValidatingBeforeUpdatingTheBalance(fetchedMemberAccount);

            if (fetchedMemberAccount.Balance < points)
            {
                throw new Exception($"Sorry, you don't have enough balance to redeem {points} points.");
            }

            fetchedMemberAccount.Balance -= points;

            return await this._unitOfWork.MemberAccounts.UpdateMemberAccountAsync(fetchedMemberAccount);
        }

        /// <summary>
        /// Retrieves the updated value from the database.
        /// Just to be on the safe side.
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <returns></returns>
        public async Task<MemberAccount> RetrieveMemberAccount(MemberAccount memberAccount)
        {
            if (memberAccount is null)
            {
                throw new Exception("Please pass a valid member account entity.");
            }

            return await this._unitOfWork.MemberAccounts.GetByIDsAsync(memberAccount.MemberID, memberAccount.AccountID);

        }

        /// <summary>
        /// Verifies if a member account is valid enough to be updated.
        /// </summary>
        /// <param name="memberAccount"></param>
        public void ValidatingBeforeUpdatingTheBalance(MemberAccount memberAccount)
        {
            //verifying if the member account exists
            if (memberAccount is null)
            {
                throw new Exception($"No member account exists for the Member ID and Account ID.");
            }

            //verifying if the member account is inactive
            if (!memberAccount.IsActive)
            {
                throw new Exception("Sorry, please activate your member account.");
            }
        }
    }
}
