using SoccerClub.GraphQLServer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.Interface
{
    public interface ITeamRepository
    {
        Task<List<TeamItem>> GetAsync();
        Task<TeamItem> GetAsync(string id);
        Task<List<MemberItem>> GetMembersAsync(string teamId, RoleEnum type);
        Task<string> CreateAsync(TeamItem team);
    }
}