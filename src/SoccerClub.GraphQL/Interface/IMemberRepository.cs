using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface IMemberRepository
    {
        Task<List<MemberItem>> GetAsync(int? skip, int? take);
        Task<MemberItem> GetAsync(string id);
        Task<List<MemberItem>> GetAsync(IEnumerable<string> ids);
        Task<MemberItem> CreateAsync(MemberInputItem item);
        Task<ILookup<string, MemberTeamIdItem>> GetLookupAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
    }
}