using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface ITeamService
    {
        Task<List<TeamItem>> GetAsync();
        Task<TeamItem> GetAsync(string id);
        Task<string> CreateAsync(TeamInputItem team);
    }
}