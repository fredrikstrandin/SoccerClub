using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface IMemberService
    {
        Task<List<MemberItem>> GetAsync(int? skip, int? take);
        Task<MemberItem> GetAsync(string id);
        Task<ILookup<string, MemberTeamIdItem>> GetAllAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
        Task<ILookup<string, MemberTeamIdItem>> GetPlayersAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
        Task<ILookup<string, MemberTeamIdItem>> GetTrainersAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
        Task<ILookup<string, MemberTeamIdItem>> GetOfficialsAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
        Task<ILookup<string, MemberTeamIdItem>> GetParentsAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
        Task<string> CreateAsync(MemberInputItem item);
    }
}