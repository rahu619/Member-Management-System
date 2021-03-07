using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LoyaltyPrime.Services.Test
{
    [TestClass]
    public class MemberAccountUnitTests
    {
        private readonly Mock<IMemberAccountRepository> _memberRepository;
        private readonly MemberAccount _memberAccount;
        public MemberAccountUnitTests()
        {
            this._memberRepository = new Mock<IMemberAccountRepository>();
            this._memberAccount = new MemberAccount { AccountID = 1, MemberID = 1, Balance = 50, IsActive = true };
        }

        /// <summary>
        /// Ideally there should multiple test scenarios here.
        /// But consolidating it into a single method, for the sake of simplicity.
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <param name="points"></param>
        [TestMethod]
        //[DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void VerifyMemberAccount()
        {
            if (this._memberAccount is null)
            {
                throw new Exception("Please pass in a valid member account");
            }

            var memberID = _memberAccount.MemberID;
            var accountID = _memberAccount.AccountID;

            var updatedMemberAccount = this._memberRepository.Object.GetByIDsAsync(memberID, accountID);
            if (updatedMemberAccount is null)
            {
                throw new Exception($"No member account exists for the Member ID:{memberID} and Account ID:{accountID}");
            }

            Assert.IsNotNull(updatedMemberAccount);
        }

        [TestMethod]
        [DataRow(40)]
        public void DeductingEnoughBalanceFromMemberAccount(int redeemPoints)
        {
            if (_memberAccount is null)
            {
                throw new Exception("Member account does not exist!");
            }
            if (!_memberAccount.IsActive)
            {
                throw new Exception("Can't redeem points from an inactive account!");
            }

            if (_memberAccount.Balance < redeemPoints)
            {
                throw new Exception($"Sorry, you don't have enough balance to redeem {redeemPoints} points.");
            }

            _memberAccount.Balance -= redeemPoints;

            Assert.AreEqual(10, _memberAccount.Balance);
        }



    }
}
