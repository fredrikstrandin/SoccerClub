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

        public Task<string> CreateAsync(TeamItem team)
        {
            team.Id = _data.NextId;

            _data.Teams.Add(team);

            return Task.FromResult(team.Id);
        }

        public Task<List<TeamItem>> GetAsync()
        {
            return Task.FromResult(_data.Teams);
        }

        public Task<TeamItem> GetAsync(string id)
        {
            return Task.FromResult(_data.Teams.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<List<MemberItem>> GetMembersAsync(string teamId, RoleEnum type)
        {
            var playerIds = _data.Teams.Where(x => x.Id == teamId)
                .FirstOrDefault()
                .Members.Where(y => y.Role == type)
                .Select(q => q.MemberId)
                .ToList();
            
            return Task.FromResult(_data.MemberList.Where(x => playerIds.Contains(x.Id)).ToList());
        }
    }
}
