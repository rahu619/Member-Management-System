using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Repository;
using LoyaltyPrime.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace LoyaltyPrime.Data
{
    /// <summary>
    /// Wrapper for all our individual repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LoyaltyPrimeDbContext _dbContext;
        private MemberRepository _memberRepository;
        private AccountRepository _accountRepository;
        private MemberAccountRepository _memberaccountRepository;

        public UnitOfWork(LoyaltyPrimeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IMemberRepository Members => _memberRepository = _memberRepository ?? new MemberRepository(this._dbContext);
        public IAccountRepository Accounts => _accountRepository = _accountRepository ?? new AccountRepository(this._dbContext);
        public IMemberAccountRepository MemberAccounts => _memberaccountRepository = _memberaccountRepository ?? new MemberAccountRepository(this._dbContext);

        public async Task<int> CommitAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
