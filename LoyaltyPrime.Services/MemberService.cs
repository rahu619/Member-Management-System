using LoyaltyPrime.Core;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<IEnumerable> GetAllMembers()
        {
            throw new NotImplementedException();
        }
    }
}
