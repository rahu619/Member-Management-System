using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// The Member service entity.
    /// </summary>
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves all the members
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a member based on the ID parameter passed in.
        /// </summary>
        /// <returns></returns>
        public async Task<Member> GetMemberAsync(int memberID)
        {
            return await this._unitOfWork.Members.SingleAsync(x => x.ID == memberID);
        }

        /// <summary>
        /// Adds a new member
        /// </summary>
        /// <param name="member"></param>
        public async Task<int> AddMemberAsync(Member member)
        {
            return await this._unitOfWork.Members.AddMemberAsync(member);
        }
    }
}
