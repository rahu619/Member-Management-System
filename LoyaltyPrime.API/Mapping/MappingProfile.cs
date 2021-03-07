using AutoMapper;
using LoyaltyPrime.API.Models;
using LoyaltyPrime.Core.Models;

namespace LoyaltyPrime.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<MemberAccount, MemberAccountDTO>();

            CreateMap<MemberDTO, Member>();
            CreateMap<AccountDTO, Account>();
            CreateMap<MemberAccountDTO, MemberAccount>();
        }
    }
}
