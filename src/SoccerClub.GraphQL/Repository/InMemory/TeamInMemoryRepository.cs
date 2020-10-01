using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository.InMemory
{
    public class TeamInMemoryRepository : ITeamRepository
    {
        private readonly InMemoryData _data;

        public TeamInMemoryRepository(InMemoryData data)
        {
            _data = data;
        }

        public Task<List<TeamItem>> GetAsync()
        {
            return Task.FromResult(_data.Teams);
        }

        public Task<TeamItem> GetAsync(string id)
        {
            return Task.FromResult(_data.Teams.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<List<MemberItem>> GetMembersAsync(string teamId, MemberType type)
        {
            List<string> playerIds = _data.TeamPlayers.Where(x => x.TeamId == teamId && x.type == type).Select(x => x.MemberId).ToList();

            return Task.FromResult(_data.MemberList.Where(x => playerIds.Contains(x.Id)).ToList());
        }
    }
}
