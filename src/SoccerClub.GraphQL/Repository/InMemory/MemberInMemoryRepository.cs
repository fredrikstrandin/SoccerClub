using SoccerClub.GraphQLServer.Interface;
using SoccerClub.GraphQLServer.Model;
using SoccerClub.GraphQLServer.Repository.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.Repository
{
    public class MemberInMemoryRepository : IMemberRepository
    {
        private readonly InMemoryData _data;

        public MemberInMemoryRepository(InMemoryData data)
        {
            _data = data;
        }

        public Task<string> CreateAsync(MemberInputItem item)
        {
            string id = _data.NextId;
            _data.MemberList.Add(new MemberItem()
            {
                Id = id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,

                Street = item.Street,
                ZIP = item.ZIP,
                City = item.City,
            });

            return Task.FromResult(id);
        }

        public Task<List<MemberItem>> GetAsync(int? skip, int? take)
        {
            return Task.FromResult(_data.MemberList.Skip(skip ?? 0).Take(take ?? int.MaxValue).ToList());
        }

        public Task<MemberItem> GetAsync(string id)
        {
            return Task.FromResult(_data.MemberList.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<ILookup<string, MemberItem>> GetAsync(IEnumerable<string> ids)
        {
            List<MemberItem> members = new List<MemberItem>();
            foreach (string id in ids)
            {
                var member = _data.MemberList.Where(x => x.Id == id).FirstOrDefault();

                if(member != null)
                {
                    members.Add(member);
                }
            }

            return Task.FromResult(members.ToLookup(x => x.Id));
        }

        public Task<ILookup<string, MemberTeamIdItem>> GetLookupAsync(IEnumerable<string> ids, RoleEnum? role, CancellationToken cancellationToken)
        {
            List<MemberTeamIdItem> teamMembers = new List<MemberTeamIdItem>();

            foreach (var teamId in ids)
            {
                TeamItem team = _data.Teams.Where(x => x.Id == teamId).FirstOrDefault();

                if(team != null)
                {
                    foreach (var teamMember in team.Members)
                    {
                        if(!(role.HasValue && teamMember.Role == role.Value))
                        {
                            continue;
                        }

                        MemberItem member = _data.MemberList.Where(x => x.Id == teamMember.MemberId).FirstOrDefault();

                        teamMembers.Add(new MemberTeamIdItem()
                        {
                            TeamId = teamId,
                            Role = teamMember.Role,
                            Id = member.Id,
                            FirstName = member.FirstName,
                            LastName = member.LastName,
                            Street = member.Street,
                            ZIP = member.ZIP,
                            City = member.City,
                            Email = member.Email,
                            Born = member.Born
                        });
                    }
                }
            }
            
            return Task.FromResult(teamMembers.ToLookup(x => x.TeamId));
        }
    }
}
