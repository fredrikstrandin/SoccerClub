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
        private readonly IMemberRepository _memberRepository;

        public TeamService(ITeamRepository teamRepository, IMemberRepository memberRepository)
        {
            _teamRepository = teamRepository;
            _memberRepository = memberRepository;
        }

        public async Task<string> CreateAsync(TeamInputItem item)
        {
            TeamItem team = new TeamItem()
            {
                Name = item.Name,
                AgeGroup = item.AgeGroup,
                Members = new List<TeamMemberItem>()
            };

            ILookup<string, MemberItem> lookupMember = await _memberRepository.GetAsync(team.Members.Select(x => x.MemberId));

            foreach (var teamMember in item.Members)
            {
                if (teamMember.Type == RoleType.Player)
                {
                    if(!lookupMember.Contains(teamMember.MemberId))
                    {
                        throw new ApplicationException($"Player {teamMember.MemberId} do not exist");
                    }

                    //It will only be one
                    MemberItem member = lookupMember[teamMember.MemberId].First();

                    if (team.AgeGroup >= member.Born.Year)
                    {
                        team.Members.Add(new TeamMemberItem() { MemberId = teamMember.MemberId, Type = teamMember.Type });
                    }
                    else
                    {
                        throw new ApplicationException($"Player {member.Id} is to old to play for this team");
                    }
                }
            }

            return await _teamRepository.CreateAsync(team);
        }

        public Task<List<TeamItem>> GetAsync()
        {
            return _teamRepository.GetAsync();
        }

        public Task<TeamItem> GetAsync(string id)
        {
            return _teamRepository.GetAsync(id);
        }
        public Task<List<MemberItem>> GetMembersAsync(string teamId, RoleType type)
        {
            return _teamRepository.GetMembersAsync(teamId, type);
        }

        Task<string> ITeamService.CreateAsync(TeamInputItem team)
        {
            throw new NotImplementedException();
        }
    }
}
