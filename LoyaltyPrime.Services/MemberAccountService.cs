using LoyaltyPrime.Core;

namespace LoyaltyPrime.Services
{
    public class MemberAccountService : IMemberAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberAccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

    }
}
