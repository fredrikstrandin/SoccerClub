using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface IMemberService
    {
        Task<List<MemberItem>> GetAsync();
        Task<MemberItem> GetAsync(string id);
    }
}