using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface IMemberRepository
    {
        Task<List<MemberItem>> GetAsync();
        Task<MemberItem> GetAsync(string id);
        Task<MemberItem> CreateAsync(MemberInputItem item);
    }
}