using System.Collections;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    public interface IMemberService
    {
        Task<IEnumerable> GetAllMembers();
    }
}
