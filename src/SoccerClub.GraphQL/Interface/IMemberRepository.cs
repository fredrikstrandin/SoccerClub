using SoccerClub.GraphQLServer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.Interface
{
    public interface IMemberRepository
    {
        Task<List<MemberItem>> GetAsync(int? skip, int? take);
        Task<MemberItem> GetAsync(string id);
        Task<ILookup<string, MemberItem>> GetAsync(IEnumerable<string> ids);
        Task<string> CreateAsync(MemberInputItem item);
        Task<ILookup<string, MemberTeamIdItem>> GetLookupAsync(IEnumerable<string> ids, RoleEnum? role, CancellationToken cancellationToken);
        
    }
}