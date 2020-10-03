﻿using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using SoccerClub.GraphQL.Repository.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository
{
    public class MemberInMemoryRepository : IMemberRepository
    {
        private readonly InMemoryData _data;

        public MemberInMemoryRepository(InMemoryData data)
        {
            _data = data;
        }

        public Task<MemberItem> CreateAsync(MemberInputItem item)
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
            

            return Task.FromResult(new MemberItem() { Id = id, FirstName = item.FirstName, LastName = item.LastName });
        }

        public Task<List<MemberItem>> GetAsync()
        {
            return Task.FromResult(_data.MemberList);
        }

        public Task<MemberItem> GetAsync(string id)
        {
            return Task.FromResult(_data.MemberList.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<List<MemberItem>> GetAsync(IEnumerable<string> ids)
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

            return Task.FromResult(members);
        }

        public async Task<ILookup<string, MemberTeamIdItem>> GetLookupAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            List<string> mIds= new List<string>();
            Dictionary<string, MemberItem> members = new Dictionary<string, MemberItem>();
            List<MemberTeamIdItem> teamMembers = new List<MemberTeamIdItem>();

            foreach (var id in ids)
            {
                var team = _data.Teams.Where(x => x.Id == id).FirstOrDefault();

                if (team != null)
                {
                    mIds.AddRange(team.Members.Select(x => x.MemberId));
                }
            }

            foreach (var memberId in mIds.Distinct())
            {
                MemberItem member = _data.MemberList.Where(x => x.Id == memberId).FirstOrDefault();

                if(member != null)
                {
                    members.Add(memberId, member);
                }
            }

            foreach (var teamId in ids)
            {
                TeamItem team = _data.Teams.Where(x => x.Id == teamId).FirstOrDefault();

                if(team != null)
                {
                    foreach (var teamMember in team.Members)
                    {
                        MemberItem member = _data.MemberList.Where(x => x.Id == teamMember.MemberId).FirstOrDefault();

                        teamMembers.Add(new MemberTeamIdItem()
                        {
                            TeamId = teamId,
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
            
            return teamMembers.ToLookup(x => x.TeamId);
        }
    }
}
