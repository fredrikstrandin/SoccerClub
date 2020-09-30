using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface ITeamRepository
    {
        Task<List<TeamItem>> GetAsync();
        Task<TeamItem> GetAsync(string id);
        Task<List<UserItem>> GetUsersAsync(string teamId, UserType type);
    }
}