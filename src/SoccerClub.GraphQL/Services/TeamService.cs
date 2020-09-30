using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Task<List<TeamItem>> GetAsync()
        {
            return _teamRepository.GetAsync();
        }

        public Task<TeamItem> GetAsync(string id)
        {
            return _teamRepository.GetAsync(id);
        }
        public Task<List<UserItem>> GetUsersAsync(string teamId, UserType type)
        {
            return _teamRepository.GetUsersAsync(teamId, type);
        }
    }
}
